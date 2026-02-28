//Program to sort string Array
using System;
class OLDEXample
{
    public static void Main()
    {
        string[] stringArray = new string[] { "Csharp", "ASP.net", "EntityFramework", "ADO.net", "WCF" };
        Array.Sort(stringArray);
        foreach (string str in stringArray)
        {
            Console.WriteLine(str + " ");
        }
          int[] intArray = new int[] { 1,4,8,56,7 };
        Array.Sort(intArray);
        foreach (int num in intArray)
        {
            Console.WriteLine(num + " ");
        }
    }
}