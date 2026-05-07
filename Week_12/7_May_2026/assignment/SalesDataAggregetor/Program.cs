using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        // Product -> Region -> Sales
        Dictionary<string, Dictionary<string, int>> sales =
            new Dictionary<string, Dictionary<string, int>>();

        // Input
        for(int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');

            string product = parts[0];
            string region = parts[1];
            int amount = int.Parse(parts[2]);

            // Create product if not exists
            if(!sales.ContainsKey(product))
            {
                sales[product] =
                    new Dictionary<string, int>();
            }

            sales[product][region] = amount;
        }

        int threshold = int.Parse(
            Console.ReadLine().Split(' ')[1]
        );

        Console.WriteLine(
            "--- Sales Report by Product and Region ---\n"
        );

        // Product reports
        foreach(var productData in sales)
        {
            string product = productData.Key;

            Dictionary<string, int> regions =
                productData.Value;

            Console.WriteLine($"Product {product}:\n");

            foreach(var regionData in regions)
            {
                Console.WriteLine(
                    $"  {regionData.Key}: ${regionData.Value}"
                );
            }

            int total = regions.Values.Sum();

            double average = regions.Values.Average();

            Console.WriteLine(
                $"  Total: ${total}, " +
                $"Average: ${average:F2}\n"
            );
        }

        // Best selling by region
        Console.WriteLine(
            "Best Selling Product by Region:\n"
        );

        // Region -> (Product, Sales)
        Dictionary<string, (string product, int sales)>
            bestByRegion =
            new Dictionary<string, (string, int)>();

        foreach(var productData in sales)
        {
            string product = productData.Key;

            foreach(var regionData in productData.Value)
            {
                string region = regionData.Key;
                int amount = regionData.Value;

                if(!bestByRegion.ContainsKey(region) ||
                   amount > bestByRegion[region].sales)
                {
                    bestByRegion[region] =
                        (product, amount);
                }
            }
        }

        foreach(var item in bestByRegion)
        {
            Console.WriteLine(
                $"{item.Key}: {item.Value.product} " +
                $"(${item.Value.sales})"
            );
        }

        // Underperforming products
        Console.WriteLine(
            $"\nUnderperforming Products (< ${threshold} average):\n"
        );

        foreach(var productData in sales)
        {
            double avg =
                productData.Value.Values.Average();

            if(avg < threshold)
            {
                Console.WriteLine(
                    $"{productData.Key} (${avg:F2})"
                );
            }
        }
    }
}