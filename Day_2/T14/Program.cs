using System;

class Calculator
{
    public double Sub(double a, double b)
    {
        return a - b;
    }

    public double Mul(double a, double b)
    {
        return a * b;
    }

    public double Div(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Division by zero is not allowed.");
            return 0;
        }

        return a / b;
    }
}

class Program
{
    static void Main()
    {
        Calculator calc = new Calculator();

        Console.Write("Enter first number: ");
        double num1 = double.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        double num2 = double.Parse(Console.ReadLine());

        Console.WriteLine("Subtraction: " + calc.Sub(num1, num2));
        Console.WriteLine("Multiplication: " + calc.Mul(num1, num2));
        Console.WriteLine("Division: " + calc.Div(num1, num2));
    }
}
