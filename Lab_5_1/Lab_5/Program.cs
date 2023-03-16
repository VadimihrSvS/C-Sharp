using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_5
{
    internal class Program
    {
        static void Main(string[] args)
        {


        }
    }

    class Triangle
    {
        double x, y, z;

        public Triangle(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double Perimeter()
        {
            return x + y + z;
        }

        public double Square()
        {
            double p = Perimeter() / 2;
            return p * (p - x) * (p - y) * (p - z);
        }

        public static Triangle operator ++(Triangle a) => new Triangle(a.x++, a.y++, a.z++);

        public static Triangle operator --(Triangle a) => new Triangle(a.x--, a.y--, a.z--);

        public static Triangle operator /(Triangle a, Triangle b)
        {
            if (b.x == 0 || b.y == 0 || b.z == 0)
            {
                throw new DivideByZeroException();

            }
            return new Triangle(a.x / b.x, a.y / b.y, a.z / b.z);
        }

        public static Triangle operator* (Triangle a, Triangle b) => new Triangle(a.x * b.x, a.y * b.y, a.z * b.z);

        public bool Equals(Triangle a)
        {
            if(a == null || !this.GetType().Equals(a.GetType()) || a.x == a.y || a.x == a.z || a.y == a.z) return false;
            return this.Square() == a.Square();
        }

        public static implicit operator Triangle(double x) => new Triangle(x, x, x);
      
        public static explicit operator double(Triangle a) => a.x;

    }

    class Task_2 {
    
    
    
    }





}
