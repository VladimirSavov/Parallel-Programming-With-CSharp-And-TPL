using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork_PP
{
	public class Multi_ThreadedVersion
	{
		static async Task Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			string text = File.ReadAllText("text.txt", System.Text.Encoding.UTF8);

			List<string> words = CleanAndTokenize(text);

			int numWords = words.Count;
			string shortestWord = "";
			string longestWord = "";
			double avgWordLength = 0;
			Dictionary<string, int> mostCommonWords = new Dictionary<string, int>();
			Dictionary<string, int> leastCommonWords = new Dictionary<string, int>();

			Console.WriteLine(stopwatch.Elapsed);
			stopwatch.Restart();
			stopwatch.Start();
			// Run tasks in parallel to calculate statistics
			await Task.WhenAll(
				Task.Run(() => { shortestWord = FindShortestWord(words); }),
				Task.Run(() => { longestWord = FindLongestWord(words); }),
				Task.Run(() => { avgWordLength = CalculateAverageWordLength(words); }),
				Task.Run(() => { mostCommonWords = FindMostCommonWords(words, 5); }),
				Task.Run(() => { leastCommonWords = FindLeastCommonWords(words, 5); })
			);


			Console.WriteLine("Multi-Threaded Version:");
			Console.WriteLine($"Number of words: {numWords}");
			Console.WriteLine($"Shortest word: {shortestWord}");
			Console.WriteLine($"Longest word: {longestWord}");
			Console.WriteLine($"Average word length: {avgWordLength:F2}");
			Console.WriteLine("Five most common words:");
			foreach (var word in mostCommonWords)
			{
				Console.WriteLine($"   - {word}");
			}
			Console.WriteLine("Five least common words:");
			foreach (var word in leastCommonWords)
			{
				Console.WriteLine($"   - {word}");
			}
            Console.WriteLine(stopwatch.Elapsed.ToString());
        }
		static List<string> CleanAndTokenize(string text)
		{
			var words = new List<string>();
			var regex = new Regex(@"\b\w+\b");

			foreach (Match match in regex.Matches(text))
			{
				string word = match.Value.ToLower();
				if (word.Length >= 3)
				{
					words.Add(word);
				}
			}

			return words;
		}

		static string FindShortestWord(List<string> words)
		{
			string shortestWord = null;

			foreach (var word in words)
			{
				if (shortestWord == null || word.Length < shortestWord.Length)
				{
					shortestWord = word;
				}
			}

			return shortestWord;
		}

		static string FindLongestWord(List<string> words)
		{
			string longestWord = null;

			foreach (var word in words)
			{
				if (longestWord == null || word.Length > longestWord.Length)
				{
					longestWord = word;
				}
			}

			return longestWord;
		}

		static double CalculateAverageWordLength(List<string> words)
		{
			int totalLength = 0;

			foreach (var word in words)
			{
				totalLength += word.Length;
			}

			return (double)totalLength / words.Count;
		}

		static Dictionary<string, int> FindMostCommonWords(List<string> words, int count)
		{
			var wordCounts = new Dictionary<string, int>();

			foreach (var word in words)
			{
				if (wordCounts.ContainsKey(word))
				{
					wordCounts[word]++;
				}
				else
				{
					wordCounts[word] = 1;
				}
			}

			var sortedWords = new List<KeyValuePair<string, int>>(wordCounts);

			sortedWords.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

			return sortedWords.GetRange(0, Math.Min(count, sortedWords.Count))
							  .ToDictionary(pair => pair.Key, pair => pair.Value);
		}

		static Dictionary<string, int> FindLeastCommonWords(List<string> words, int count)
		{
			var wordCounts = new Dictionary<string, int>();

			foreach (var word in words)
			{
				if (wordCounts.ContainsKey(word))
				{
					wordCounts[word]++;
				}
				else
				{
					wordCounts[word] = 1;
				}
			}

			var sortedWords = new List<KeyValuePair<string, int>>(wordCounts);

			sortedWords.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

			return sortedWords.GetRange(0, Math.Min(count, sortedWords.Count))
							  .ToDictionary(pair => pair.Key, pair => pair.Value);
		}
	}
}