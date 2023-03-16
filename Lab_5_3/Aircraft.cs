using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    [Serializable]
    internal abstract class Aircraft // родительский класс ВОЗДУШНОЕ СУДНО
    {
        private double m; //m - масса полезной нагрузки
        private double g; //g - вес пустого

        protected Aircraft()
        {
            m = 0;
            g = 0;
        }

        protected Aircraft(double g, double m)
        {
            G = g;
            M = m;
        }

        public double G { get => g; set => g = value; }
        public double M { get => m; set => m = value; }

        public abstract double UdelNagr(int k); //метод определения удельной нагрузки
        public abstract double Keff(); //метод определения коэффициента эффективности
        public virtual void Print()
        {
            Console.WriteLine($"Воздушное судно массой {G}, полезная нагрузка {M}");
        }
    }
}
