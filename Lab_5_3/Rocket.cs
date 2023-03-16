using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Rocket : Aircraft
    {
        public Rocket()//пустой конструктор
        {
        }

        public Rocket(double g, double m) : base(g, m)
        {
        }

        public override double Keff() // коэфф. эффективности равен отношению масс груза и массы возд.судна
        {
            return M / G;
        }

        public override double UdelNagr(int k) // удельная нагрузка 
        {
            return 0; //  нет винта или крыла (опорной поверхности) поэтому удельная нагрузка 0
        }

        new public void Print()
        {
            base.Print();
            Console.WriteLine($"Ракета массой {M}, полезной нагрузкой {G}");

        }
    }
}
