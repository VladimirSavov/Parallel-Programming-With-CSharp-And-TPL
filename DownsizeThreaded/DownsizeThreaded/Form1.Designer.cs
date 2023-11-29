namespace DownsizeThreaded
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            textBoxScalingFactor = new TextBox();
            pictureBoxOriginal = new PictureBox();
            pictureBoxDownscaled = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDownscaled).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(317, 59);
            button1.Name = "button1";
            button1.Size = new Size(122, 37);
            button1.TabIndex = 0;
            button1.Text = "Browse";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(317, 102);
            button2.Name = "button2";
            button2.Size = new Size(122, 37);
            button2.TabIndex = 1;
            button2.Text = "Downsize";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBoxScalingFactor
            // 
            textBoxScalingFactor.Location = new Point(152, 30);
            textBoxScalingFactor.Name = "textBoxScalingFactor";
            textBoxScalingFactor.Size = new Size(471, 23);
            textBoxScalingFactor.TabIndex = 2;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Location = new Point(25, 145);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(294, 292);
            pictureBoxOriginal.TabIndex = 3;
            pictureBoxOriginal.TabStop = false;
            // 
            // pictureBoxDownscaled
            // 
            pictureBoxDownscaled.Location = new Point(453, 145);
            pictureBoxDownscaled.Name = "pictureBoxDownscaled";
            pictureBoxDownscaled.Size = new Size(294, 292);
            pictureBoxDownscaled.TabIndex = 4;
            pictureBoxDownscaled.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(25, 114);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 5;
            label1.Text = "Original";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(633, 117);
            label2.Name = "label2";
            label2.Size = new Size(114, 25);
            label2.TabIndex = 6;
            label2.Text = "Downscaled";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(152, 9);
            label3.Name = "label3";
            label3.Size = new Size(464, 15);
            label3.TabIndex = 7;
            label3.Text = "Enter your downscaling factor =>It's percentage between 1 and 100 of the original size!\r\n";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBoxDownscaled);
            Controls.Add(pictureBoxOriginal);
            Controls.Add(textBoxScalingFactor);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxDownscaled).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private TextBox textBoxScalingFactor;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBoxDownscaled;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}