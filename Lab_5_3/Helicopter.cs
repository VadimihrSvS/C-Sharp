using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Helicopter : Aircraft // класс наследник ВЕРТОЛЕТ
    {
        double rrotor; //радиус несущего винта

        public Helicopter(double g, double m, double rrotor) : base(g, m)
        {
            Rrotor = rrotor;
        }

        public double Rrotor { get => rrotor; set => rrotor = value; }

        public override double Keff()
        {
            return M/G;
        }

        public override double UdelNagr(int k) // удельная нагрузка равна отношению снаряженной массы к площади ометаемой винтом
        {
            return (M + G) / (Math.PI * Rrotor * Rrotor); 
        }
    }
}
