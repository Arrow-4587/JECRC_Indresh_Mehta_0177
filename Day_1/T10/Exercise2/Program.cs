using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter number value: ");
        int numberValue = int.Parse(Console.ReadLine());
        int widthValue = 6;
        for (int i = widthValue; i >= 1; i--)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(numberValue + " ");
            }
            Console.WriteLine();
        }
    }
}