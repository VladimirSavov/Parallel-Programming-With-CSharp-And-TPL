using System.Diagnostics;
using System.Windows.Forms;

namespace DownsizeThreaded
{
    public partial class Form1 : Form
    {
        private Bitmap originalImage;
        private object lockObject = new object();
        public Form1()
        {
            InitializeComponent();
        }

        private Bitmap DownscaleImage(Bitmap originalImage, double scalingFactor)
        {
            int newWidth = (int)(originalImage.Width * scalingFactor / 100);
            int newHeight = (int)(originalImage.Height * scalingFactor / 100);
            Bitmap downscaledImage = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(downscaledImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return downscaledImage;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "File Extensions|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    lock (lockObject)
                    {
                        originalImage = new Bitmap(selectedFile);
                        pictureBoxOriginal.Image = originalImage;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please select image first.");
                return;
            }

            if (double.TryParse(textBoxScalingFactor.Text, out double scalingFactor) && scalingFactor > 0)
            {

                Stopwatch watch = new Stopwatch();
                watch.Restart();

                Thread thread = new Thread(() =>
                {
                    Bitmap downsized = DownscaleImage(originalImage, scalingFactor);
                    lock (lockObject)
                    {
                        pictureBoxDownscaled.Image = downsized;
                    }
                });

                thread.Start();
                thread.Join();

                watch.Stop();
                string message = watch.ElapsedMilliseconds.ToString();
                MessageBox.Show("Изминалото време е: " + message + " ms.");

            }
            else
            {
                MessageBox.Show("Invalid downscaling factor.");
            }
        }
    }
}