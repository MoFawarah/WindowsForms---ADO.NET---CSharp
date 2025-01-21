using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstClassLibrary;

namespace MyFirstClassLibrary
{
    public class MathClassLib
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }

        
        public int Sum(int x, int y, int z)
        {
            return x + y + z;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public float Divide(float x, float y)
        {
            return (float)(x / y) + 2;
        }
    }
}
