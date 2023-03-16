using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadan_1
{
    class Cars : IDrive, IComparable //класс "автомобиль", наследует интерфейс "езда"
    {

        //поля, класса Cars

        private double weight; //масса, т 
        private string mark; //марка
        private string model; //модель
        private int speed; //скорость, км/ч

        //свойства, класса Cars

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value > 0.5) { weight = value; }
                else weight = 1.0; //
            }
        }

        public string Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
            }
        }

        protected string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }


        //конструкторы, класса Cars

        public Cars(double w, string mr, string md, int sp)
        {
            Weight = w;
            Mark = mr;
            Model = md;
            Speed = sp;
            if (Speed != 0) { status = "движется"; }
            else status = "стоит";
        } //конструктор с полным набором параметров

        public Cars() : this(1.0, "X", "X", 0) { }  //пустой конструктор


        //методы, класса Cars

        public virtual string GetInfo()
        {
            return "\tАвтомобиль\n" + "Масса: " + Weight + " т" + "\nМарка: " + Mark
                + "\nМодель: " + Model + "\nСкорость: " + Speed + " км/ч";
        } //информация о автомобиле

        //реализованные методы и свойства интерфейса IDrive, классом Cars

        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value >= 0 && value <= 200) speed = value;
                else speed = 0;
            }

        } //скорость

        public string status { get; set; } //состояние машины

        public void Status_casting()
        {
            if (status != "стоит")
            {
                Console.WriteLine($"Автомобиль {Mark} {status} со скоростью {Speed} км/ч.");
            }
            else Console.WriteLine($"Автомобиль {Mark} {status} на месте.");
        } //информация о состоянии движения (кастинг)

        public virtual void Status_gluing()
        {

            if (status != "стоит")
            {
                Console.WriteLine($"Автомобиль {Mark} {status} со скоростью {Speed} км/ч.");
            }
            else Console.WriteLine($"Автомобиль {Mark} {status} на месте.");
        } //информация о состоянии движения (склеивание)

        public int Start()
        {
            if (Speed == 0)
            {
                Speed = 20;
                status = "движется";
                return 0;
            }
            else return 1;
        } //начать движение

        public int Stop()
        {
            if (Speed != 0)
            {
                Speed = 0;
                return 0;
            }
            else return 1;
        } //остановиться

        int IComparable.CompareTo(object o)
        {
            Cars buf = o as Cars;
            if (buf != null)
            {
                string x = buf.Mark;
                int res;
                res = String.Compare(this.Mark, x);
                if (res > 0) { return 1; }
                else if (res < 0) { return -1; }
                else return 0;
            }
            else throw new ArgumentException("Объект не является Cars!");
        }

    }
}
