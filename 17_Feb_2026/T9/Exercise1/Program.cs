// Write a C# sharp program that takes three letters as input and display them in reverse order
//Test Case:
/* Enter Letter: O
 * Enter Letter: D
 * Enter Letter: L
 */
//Expected Output: LDO

using System;
class Program
{
    static void Main()
    {
        Console.Write("Enter Letter: ");
        char letter1 = Console.ReadLine()[0];    // this
        Console.Write("Enter Letter: ");
        char letter2 = Convert.ToChar(Console.ReadLine());    // and this both are valid    
        Console.Write("Enter Letter: ");
        char letter3 = Console.ReadLine()[0];
        Console.WriteLine($"Reversed Letters: {letter3}{letter2}{letter1}");
    }
}