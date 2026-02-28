// using System;

// class Demo
// {
//     private static int number;

//     public static int Number
//     {
//         get { return number; }
//     }

//     static Demo()
//     {
//         Random r = new Random();
//         number = r.Next();
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine(Demo.Number);
//     }
// }

// using System;
// class OLDExercise
// {
//     private int number;
//     public int Number{
//         get
//         {
//             return number;
//         }
//     }
//     public OLDExercise()
//     {
//         Random r = new Random();
//         number = r.Next();
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         OLDExercise a = new OLDExercise();
//         Console.WriteLine("Static Number = " + a.Number);
//     }
// }

using System;
class OLDExercise
{
    private int number;
    public int Number{
        get
        {
            return number;
        }
    }
    public OLDExercise()
    {
        Random r = new Random();
        number = r.Next();
    }
     public OLDExercise(int seed)
    {
        Random r = new Random(seed);
        number = r.Next();
    }
}

class Program
{
    static void Main(string[] args)
    {
        OLDExercise num = new OLDExercise();
        Console.WriteLine("Static Number = " + num.Number);
         OLDExercise num1 = new OLDExercise(500);
         Console.WriteLine("Static Number = " + num1.Number);
    }
}