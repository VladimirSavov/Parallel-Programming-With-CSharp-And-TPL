using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HomeWork_PP
{
	public class Non_ThreadedVersion
	{

		static void Main(string[] args)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			string text = File.ReadAllText("text.txt", System.Text.Encoding.UTF8);
		// Tokenize the text and perform analysis
		var words = CleanAndTokenize(text);

		// 1. Number of words
		int numWords = words.Count;

		// 2. Shortest word
		string shortestWord = FindShortestWord(words);

		// 3. Longest word
		string longestWord = FindLongestWord(words);

		// 4. Average word length
		double avgWordLength = CalculateAverageWordLength(words);

		// 5. Five most common words
		var mostCommonWords = FindMostCommonWords(words, 5);

		// 6. Five least common words
		var leastCommonWordsMulti = FindLeastCommonWords(words, 5);

		// Print the results
		Console.WriteLine("1. Number of words: " + numWords);
			Console.WriteLine("2. Shortest word: " + shortestWord);
			Console.WriteLine("3. Longest word: " + longestWord);
			Console.WriteLine("4. Average word length: " + avgWordLength.ToString("F2"));
			Console.WriteLine("5. Five most common words:");
			foreach (var pair in mostCommonWords)
			{
				Console.WriteLine($"   - {pair.Key}: {pair.Value} times");
			}
	Console.WriteLine("6. Five least common words:");
			foreach (var pair in leastCommonWordsMulti)
			{
				Console.WriteLine($"   - {pair.Key}: {pair.Value} times");
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
