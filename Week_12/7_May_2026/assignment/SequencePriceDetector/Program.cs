using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] arr = {1,3,2,3,3,4,5,3,6,7,8,9,10,3};

        int K = 2;

        Console.WriteLine("--- Access Pattern Analysis ---\n");

        // -------------------------------
        // 1. Longest Consecutive Sequence
        // -------------------------------

        HashSet<int> set = new HashSet<int>(arr);

        int longestLength = 0;
        int startNumber = 0;

        foreach(int num in set)
        {
            // Start only if previous number doesn't exist
            if(!set.Contains(num - 1))
            {
                int current = num;
                int length = 1;

                while(set.Contains(current + 1))
                {
                    current++;
                    length++;
                }

                if(length > longestLength)
                {
                    longestLength = length;
                    startNumber = num;
                }
            }
        }

        List<int> sequence = new List<int>();

        for(int i = 0; i < longestLength; i++)
        {
            sequence.Add(startNumber + i);
        }

        Console.WriteLine(
            $"Longest Consecutive Sequence: " +
            $"{string.Join(",", sequence)} " +
            $"(Length: {longestLength})\n"
        );

        // -------------------------------
        // 2. Most Frequent Element
        // -------------------------------

        Dictionary<int, int> freq =
            new Dictionary<int, int>();

        foreach(int num in arr)
        {
            if(freq.ContainsKey(num))
                freq[num]++;
            else
                freq[num] = 1;
        }

        var mostFreq = freq.OrderByDescending(x => x.Value)
                           .First();

        Console.WriteLine(
            $"Most Frequent Element: " +
            $"{mostFreq.Key} " +
            $"(appears {mostFreq.Value} times)\n"
        );

        // -------------------------------
        // 3. First Non-Repeating Element
        // -------------------------------

        int firstNonRepeating = -1;

        foreach(int num in arr)
        {
            if(freq[num] == 1)
            {
                firstNonRepeating = num;
                break;
            }
        }

        Console.WriteLine(
            $"First Non-Repeating Element: " +
            $"{firstNonRepeating}\n"
        );

        // -------------------------------
        // 4. Pairs with Difference K
        // -------------------------------

        Console.WriteLine($"Pairs with Difference {K}:\n");

        HashSet<string> printed = new HashSet<string>();

        foreach(int num in set)
        {
            if(set.Contains(num + K))
            {
                string pair = $"({num}, {num + K})";

                if(!printed.Contains(pair))
                {
                    printed.Add(pair);
                    Console.Write(pair + " ");
                }
            }
        }

        Console.WriteLine("\n");

        // -------------------------------
        // 5. Majority Element
        // -------------------------------

        int n = arr.Length;

        var majority = freq.OrderByDescending(x => x.Value)
                           .First();

        double percentage =
            (majority.Value * 100.0) / n;

        if(majority.Value > n / 2)
        {
            Console.WriteLine(
                $"Majority Element: {majority.Key}"
            );
        }
        else
        {
            Console.WriteLine(
                $"Majority Element: {majority.Key} " +
                $"(appears {majority.Value} out of {n} times - " +
                $"{percentage:F1}% - No majority)"
            );
        }
    }
}