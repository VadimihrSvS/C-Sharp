using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadan_1
{
    class Wagon : Cars, IShipping, IDrive//(явное наследование IDrive, для реализации кастинга)
    //закрытый класс для наследования "фура", наследует класс "автомобиль" и интерфейс "перевозка груза"
    {
        //поля, класса Wagon

        private bool trailer; //прицеп, (есть/нет)
        private bool cargo; //груз, (есть/нет)
        private double weight_trailer; //масса прицепа, т
        private double weight_cargo; //масса груза, т

        //свойства, класса Wagon

        public bool Trailer
        {
            get
            {
                return trailer;
            }
            set
            {
                trailer = value;
            }
        }

        public double WTrailer
        {
            get
            {
                return weight_trailer;
            }
            set
            {
                if (Trailer == true) { weight_trailer = value; }
                else weight_trailer = 0.0; //если нет прицепа, то нет и его массы
            }
        }

        //конструкторы, класса Wagon

        public Wagon(double w, string mr, string md, int sp, bool trailer, bool cargo, double wt, double wc)
            : base(w, mr, md, sp)
        {
            Trailer = trailer;
            Cargo = cargo;
            WTrailer = wt;
            WCargo = wc;
        } //конструктор с полным набором параметров

        public Wagon() : base()
        {
            Trailer = false;
            Cargo = false;
            WTrailer = 0;
            WCargo = 0;
            Weight = 4;
        } //пустой конструктор

        //методы, класса Wagon

        public int Add_Trailer() //добавить прицеп к тягочу
        {
            if (Trailer == false)
            {
                Trailer = true;
                WTrailer = 15.0;
                return 0;
            }
            else return 1;
        }

        public int Del_Trailer() //удалить прицеп
        {
            if (Trailer == true)
            {
                Trailer = false;
                WTrailer = 0.0;
                return 0;
            }
            else return 1;
        }

        public override string GetInfo() //информация о автомобиле 
        {
            return "\tФура\n" + "Масса: " + Weight + " т" + "\nМарка: " + Mark
                + "\nМодель: " + Model + "\nСкорость: " + Speed + " км/ч" + "\nПрицеп: " + Trailer +
                "\nГруз: " + Cargo + "\nМасса прицепа: " +
                weight_trailer + " т" + "\nМасса груза: " + weight_cargo + " т" + "\n";
        }

        //реализованные методы и свойства интерфейса IShipping, классом Wagon

        public bool Cargo
        {
            get
            {
                return cargo;
            }
            set
            {
                if (Trailer == true) { cargo = value; }
                else cargo = false;  //если нет прицепа, то нет и груза
            }
        }

        public double WCargo
        {
            get
            {
                return weight_cargo;
            }
            set
            {
                if (Cargo == true) { weight_cargo = Math.Abs(value); }
                else weight_cargo = 0.0; //если нет груза, то нет и его массы
            }
        }

        public int Add_Cargo() //добавить груз к фуре (загрузить фуру)
        {
            if (Trailer == true && Cargo != true)
            {
                Cargo = true;
                Console.WriteLine("Масса груза:");
                WCargo = Convert.ToDouble(Console.ReadLine());
                return 0;
            }
            else return 1;
        }

        public int Del_Cargo() //убрать груз из фуры (разгрузить фуру)
        {
            if (WCargo != 0.0)
            {
                Cargo = false;
                WCargo = 0.0;
                return 0;
            }
            else return 1;
        }

        void IDrive.Status_casting()
        {
            if (status != "стоит")
            {
                Console.WriteLine($"Фура {Mark} {status} со скоростью {Speed} км/ч.");
            }
            else Console.WriteLine($"Фура {Mark} {status} на месте.");
        } //информация о состоянии движения (кастинг) 

        void IShipping.Status_casting()
        {
            if (Cargo) { Console.WriteLine($"Фура {Mark} перевозит груз массой - {WCargo} т."); }
            else { Console.WriteLine($"Фура {Mark} без груза."); }
        }//информация о перевозке груза (кастинг)

        public void StatusShipping()
        {
            ((IShipping)this).Status_casting();
        } //информация о перевозке груза (обертывание)

        public void StatusDrive()
        {
            ((IDrive)this).Status_casting();
        } //информация о состоянии движения (обертывание)

        public override void Status_gluing()
        {
            if (status != "стоит") { Console.WriteLine($"Фура {Mark} {status} со скоростью {Speed} км/ч."); }
            else Console.WriteLine($"Фура {Mark} {status} на месте.");
            //------------------------------------------------------------------------
            if (Cargo) { Console.WriteLine($"Фура {Mark} перевозит груз массой - {WCargo} т."); }
            else { Console.WriteLine($"Фура {Mark} без груза."); }
        } //реализация метода Status_gluing(), путем склеивания

    }
}
