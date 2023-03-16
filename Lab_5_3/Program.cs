using System;

namespace Lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane plane1 = new Plane(3500, 500, 10, 2); //создадим оъект Plane1
            plane1.Print();
            Console.WriteLine($"Удельная нагрузка на крыло самолета с коэфф.1 = {plane1.UdelNagr(1):0.000} ");//
            Console.WriteLine();

            Plane.SaveClass("c:\\Temp1\\1.txt"); //рефлексия
            plane1.SaveObject("c:\\Temp1\\1.bin"); //сохранение в бинарном файле

            Plane plane2 = Plane.LoadObject("c:\\Temp1\\1.bin"); //востановление из бинарного файла
            plane2.Print();
            Console.WriteLine($"Удельная нагрузка на крыло самолета коэфф.2= {plane2.UdelNagr(2):0.000} ");
            Console.WriteLine();

            plane2.Serialize("c:\\Temp1\\2.bin");// сериализация - сохранение объекта
            Plane plane3 = Plane.Deserialize("c:\\Temp1\\2.bin");// десериализация - востановление объекта
            plane3.Print();
            Console.WriteLine($"Удельная нагрузка на крыло самолета коэфф.5= {plane2.UdelNagr(5):0.000} ");
        }
    }
}
