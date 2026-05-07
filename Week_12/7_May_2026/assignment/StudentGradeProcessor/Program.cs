using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        // Store student -> grades
        Dictionary<string, int[]> students =
            new Dictionary<string, int[]>();

        // Store unique grades
        HashSet<int> uniqueGrades =
            new HashSet<int>();

        // Input
        for(int i = 0; i < n; i++)
        {
            string[] parts = Console.ReadLine().Split(' ');

            string name = parts[0];

            int[] grades = parts.Skip(1)
                                .Select(int.Parse)
                                .ToArray();

            students[name] = grades;

            // Add grades to HashSet
            foreach(int grade in grades)
            {
                uniqueGrades.Add(grade);
            }
        }

        Console.WriteLine("--- Student Grade Report ---\n");

        string topStudent = "";
        double topAverage = 0;

        // Process each student
        foreach(var student in students)
        {
            string name = student.Key;
            int[] grades = student.Value;

            double average = grades.Average();
            int highest = grades.Max();
            int lowest = grades.Min();

            Console.WriteLine(
                $"{name}: Average = {average:F2}, " +
                $"Highest = {highest}, Lowest = {lowest}"
            );

            // Track topper
            if(average > topAverage)
            {
                topAverage = average;
                topStudent = name;
            }
        }

        // Top performer
        Console.WriteLine(
            $"\nTop Performer: {topStudent} " +
            $"(Average: {topAverage:F2})"
        );

        // Students with all grades >= 80
        Console.WriteLine(
            "\nStudents with all grades >= 80:\n"
        );

        foreach(var student in students)
        {
            if(student.Value.All(x => x >= 80))
            {
                Console.WriteLine(
                    $"{student.Key} " +
                    $"({string.Join(",", student.Value)})"
                );
            }
        }

        // Unique grades
        Console.WriteLine(
            "\nUnique Grade Values Across All Students:\n"
        );

        var sortedGrades = uniqueGrades.OrderBy(x => x);

        Console.WriteLine(
            string.Join(",", sortedGrades)
        );

        Console.WriteLine(
            $"Total unique grades: {uniqueGrades.Count}"
        );
    }
}