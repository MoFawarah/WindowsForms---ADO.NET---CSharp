using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstClassLibrary
{
    public class StringLib
    {
        internal string SFirstName { get; set; }
        internal protected string SLastName { get; set; }
        internal protected void CombineThreeStrings(string s1, string s2, string s3)
        {
            Console.WriteLine(s1 + s2 + s3);
        }
        internal void CombineTwoStrings(string s1, string s2)
        {
            Console.WriteLine(s1 + s2);
        }
    }
}
