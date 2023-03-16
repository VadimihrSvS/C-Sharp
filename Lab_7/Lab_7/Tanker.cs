using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadan_1
{
    class Tanker// : IShipping //класс "танкер" (грузовой корабль), наследует интерфейс "перевозка груза"
    {
        //поля, класса Tanker

        private double weight; //масса танкера, т
        private double weight_cargo; //масса груза, т

        //свойства, класса Tanker

        public string Name { get; set; } //"имя" танкера

        public double Weight
        {
            get
            {
                return weight;
            }

            set
            {
                if (value >= 10000 && value <= 500000) { weight = value; }
                else weight = 10000;
            }


        }

        //конструкторы, класса Tanker

        public Tanker()
        {
            Name = "NoName";
            Weight = 10000;
            Cargo = false;
            WCargo = 0.0;
        }

        public Tanker(string name) : this()
        {
            Name = name;
        }

        public Tanker(string name, double weight, bool cargo, double wc)
        {
            Name = name;
            Weight = weight;
            Cargo = cargo;
            WCargo = wc;
        }

        //реализованные методы и свойства интерфейса IShipping, классом Tanker

        public bool Cargo { get; set; } //груз (есть/нет)

        public double WCargo
        {
            get
            {
                return weight_cargo;
            }
            set
            {
                if (value >= 1.0 && (value < Weight) && Cargo == true) { weight_cargo = value; }
                else weight_cargo = 0.0;
            }
        } //масса груза, т

        public int Add_Cargo()
        {
            if (Cargo == false || (Cargo == true && WCargo == 0.0))
            {
                Cargo = true;
                Console.WriteLine("Масса груза:");
                WCargo = Convert.ToDouble(Console.ReadLine());
                return 0;
            }
            else return 1;
        } //добавить груз

        public int Del_Cargo()
        {
            if (WCargo != 0.0)
            {
                WCargo = 0.0;
                return 0;
            }
            else return 1;
        } //удалить груз

        public void Status_gluing()
        {
            if (Cargo && WCargo != 0.0)
            {
                Console.WriteLine($"Танкер - {Name}, перевозит груз массой {WCargo} т.");
            }
            else Console.WriteLine($"Танкер - {Name}, не перевозит груз.");
        } //информация о перевозке груза (склеивание)

        public void Status_casting()
        {
            if (Cargo && WCargo != 0.0)
            {
                Console.WriteLine($"Танкер - {Name}, перевозит груз массой {WCargo} т.");
            }
            else Console.WriteLine($"Танкер - {Name}, не перевозит груз.");
        }  //информация о перевозке груза (кастинг)


    }
}
