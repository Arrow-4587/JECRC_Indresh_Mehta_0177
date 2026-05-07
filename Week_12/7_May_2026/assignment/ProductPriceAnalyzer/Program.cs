using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] prices = {299,499,199,399,599,159,699,259};

        int target = 698;

        Console.WriteLine("--- Product Price Analysis ---\n");

        Console.WriteLine(
            "Original Prices: " +
            string.Join(", ", prices)
        );

        // Copy array for sorting
        int[] sorted = (int[])prices.Clone();

        // Bubble Sort
        BubbleSort(sorted);

        Console.WriteLine(
            "\nSorted Prices (Ascending): " +
            string.Join(", ", sorted)
        );

        // Binary Search
        Console.WriteLine("\nBinary Search Results:\n");

        SearchAndPrint(sorted, 399);
        SearchAndPrint(sorted, 500);

        // Pair Sum
        Console.WriteLine(
            $"\nPairs that sum to {target}:\n"
        );

        FindPairs(sorted, target);

        // Longest Increasing Subsequence
        var lis = LongestIncreasingSubsequence(sorted);

        Console.WriteLine(
            "\nLongest Increasing Subsequence:\n"
        );

        Console.WriteLine(
            $"{string.Join(", ", lis)} " +
            $"(Length: {lis.Count})"
        );

        // Statistics
        Console.WriteLine("\nStatistics:\n");

        Console.WriteLine(
            $"Lowest Price: {sorted.Min()}"
        );

        Console.WriteLine(
            $"Highest Price: {sorted.Max()}"
        );

        Console.WriteLine(
            $"Average Price: {sorted.Average():F2}"
        );

        double median;

        int n = sorted.Length;

        if(n % 2 == 0)
        {
            median =
                (sorted[n/2 - 1] + sorted[n/2]) / 2.0;
        }
        else
        {
            median = sorted[n/2];
        }

        Console.WriteLine(
            $"Median Price: {median:F2}"
        );
    }

    // Bubble Sort
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;

        for(int i = 0; i < n - 1; i++)
        {
            for(int j = 0; j < n - i - 1; j++)
            {
                if(arr[j] > arr[j + 1])
                {
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Binary Search
    static int BinarySearch(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while(left <= right)
        {
            int mid = (left + right) / 2;

            if(arr[mid] == target)
                return mid;

            if(arr[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return -1;
    }

    static void SearchAndPrint(int[] arr, int target)
    {
        int index = BinarySearch(arr, target);

        if(index != -1)
        {
            Console.WriteLine(
                $"Price {target} found at index {index}"
            );
        }
        else
        {
            Console.WriteLine(
                $"Price {target} not found"
            );
        }
    }

    // Pair Sum
    static void FindPairs(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while(left < right)
        {
            int sum = arr[left] + arr[right];

            if(sum == target)
            {
                Console.WriteLine(
                    $"({arr[left]}, {arr[right]})"
                );

                left++;
                right--;
            }
            else if(sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
    }

    // Longest Increasing Subsequence
    static List<int> LongestIncreasingSubsequence(
        int[] arr)
    {
        List<int> lis = new List<int>();

        lis.Add(arr[0]);

        for(int i = 1; i < arr.Length; i++)
        {
            if(arr[i] > lis[lis.Count - 1])
            {
                lis.Add(arr[i]);
            }
        }

        return lis;
    }
}