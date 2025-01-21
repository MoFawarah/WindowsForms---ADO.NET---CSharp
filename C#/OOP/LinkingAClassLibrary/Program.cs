using MyFirstClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkingAClassLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MathClassLib mathObj = new MathClassLib();
            Console.WriteLine(mathObj.Sum(1, 2));
            Console.WriteLine(mathObj.Sum(1, 2, 3));
            Console.WriteLine(mathObj.Multiply(1, 2));
            Console.WriteLine(mathObj.Divide(1, 2));
        }
    }
}
