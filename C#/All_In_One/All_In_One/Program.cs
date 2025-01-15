
//ProgrammingAdvices.com
//Mohammed Abu-Hadhoud

using System;
using System.Linq;

namespace Main
{
    enum enGender
    {
        Male,
        Female
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(rnd.Next(0,3)); 
            }




        }
    }
}

