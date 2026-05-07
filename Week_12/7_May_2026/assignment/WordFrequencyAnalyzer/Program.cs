using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string text = @"The quick brown fox jumps over the lazy dog. 
                        The fox is quick and the dog is lazy. 
                        Quick brown fox jumps over the lazy dog again.";

        int N = 3;

        // Convert to lowercase
        text = text.ToLower();

        // Remove punctuation
        text = Regex.Replace(text, @"[^\w\s]", "");

        // Split into words
        string[] words = text.Split(' ',
                         StringSplitOptions.RemoveEmptyEntries);

        // Dictionary for frequency
        Dictionary<string, int> freq =
            new Dictionary<string, int>();

        // Count frequency
        foreach(string word in words)
        {
            if(freq.ContainsKey(word))
            {
                freq[word]++;
            }
            else
            {
                freq[word] = 1;
            }
        }

        Console.WriteLine("--- Word Frequency Analysis ---\n");

        Console.WriteLine($"Total words: {words.Length}");

        Console.WriteLine($"Unique words: {freq.Count}\n");

        // Top N frequent words
        Console.WriteLine($"Top {N} Frequent Words:\n");

        var topWords = freq.OrderByDescending(x => x.Value)
                           .ThenBy(x => x.Key)
                           .Take(N);

        foreach(var item in topWords)
        {
            Console.WriteLine($"{item.Key}: {item.Value} times");
        }

        // Words appearing once
        Console.WriteLine("\nWords appearing exactly once:\n");

        var onceWords = freq.Where(x => x.Value == 1)
                            .Select(x => x.Key)
                            .OrderBy(x => x);

        Console.WriteLine(string.Join(", ", onceWords));

        // Average frequency
        double average = freq.Values.Average();

        Console.WriteLine($"\nAverage frequency: {average:F2} times per unique word");
    }
}