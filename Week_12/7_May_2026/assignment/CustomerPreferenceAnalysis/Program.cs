Console.WriteLine("Hello, World!");
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Creating HashSets
        HashSet<string> electronics = new HashSet<string>
        {
            "C001","C002","C003","C005","C008"
        };

        HashSet<string> clothing = new HashSet<string>
        {
            "C002","C004","C005","C006","C009"
        };

        HashSet<string> books = new HashSet<string>
        {
            "C003","C005","C007","C008","C010"
        };

        Console.WriteLine("--- Customer Preference Analysis ---\n");

        // 1. UNION -> ANY category
        var anyCategory = electronics
                          .Union(clothing)
                          .Union(books)
                          .OrderBy(x => x);

        Console.WriteLine("1. Customers in ANY category (Union):");

        Console.WriteLine(string.Join(", ", anyCategory));

        Console.WriteLine($"Total: {anyCategory.Count()} customers\n");

        // 2. INTERSECTION -> ALL categories
        var allCategory = electronics
                          .Intersect(clothing)
                          .Intersect(books);

        Console.WriteLine("2. Customers in ALL categories (Intersection):");

        Console.WriteLine(string.Join(", ", allCategory));

        Console.WriteLine($"Total: {allCategory.Count()} customers\n");

        // 3. ONLY Electronics
        var onlyElectronics = electronics
                              .Except(clothing)
                              .Except(books);

        Console.WriteLine("3. Customers ONLY in Electronics:");

        Console.WriteLine(string.Join(", ", onlyElectronics));

        Console.WriteLine($"Total: {onlyElectronics.Count()} customers\n");

        // 4. Electronics AND Books but NOT Clothing
        var specialCustomers = electronics
                               .Intersect(books)
                               .Except(clothing);

        Console.WriteLine("4. Customers in Electronics AND Books but NOT Clothing:");

        Console.WriteLine(string.Join(", ", specialCustomers));

        Console.WriteLine($"Total: {specialCustomers.Count()} customers");
    }
}