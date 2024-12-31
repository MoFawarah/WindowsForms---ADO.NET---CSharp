
//ProgrammingAdvices.com
//Mohammed Abu-Hadhoud

using System;

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
 
        var User1 = new
        {
            FirstName = "Abdullrahman",
            FatherName = "Abdullah",
            LastName = "Al-Akhzami",
            Age = 21,
            Gender = enGender.Male
        };

        string InfoCard1 = $"\n\n{(User1.Gender == enGender.Male ? "Mr." : "Ms.")} {User1.FirstName} {(User1.Gender == enGender.Male ? "Ben" : "Bent")} {User1.FatherName} {User1.LastName}, It was {User1.Age}";
        string InfoCard2 = $"{(User1.Gender == enGender.Female? "Ms":"Mr")}";

        Console.WriteLine(InfoCard1);

        }
    }
}

