using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadan_1
{
    class main
    {
        static void Main(string[] args)
        {
            //объекты
            Wagon A = new Wagon(3.5, "Volvo", "S60", 58, true, true, 4.2, 4.2); //фура
            Cars B = new Cars(2.1, "Audi", "A8", 150); //легковой автомобиль            

            //-----------------------------------------------------------------------------------------------
            //2.Коллизия имен
            //-----------------------------------------------------------------------------------------------
            Console.WriteLine("---Реализация склеивания методов Status_gluing() интерфейсов IDrive, IShipping---\n");
            A.Status_gluing(); //склеивание

            Console.WriteLine("\n---Реализация кастинга метода Status_casting() интерфейса IDrive---\n");
            ((IDrive)A).Status_casting(); //кастинг

            Console.WriteLine("\n---Реализация кастинга метода Status_casting() интерфейса IShipping---\n");
            ((IShipping)A).Status_casting(); //кастинг

            Console.WriteLine("\n---Реализация обертывания метода Status_casting() интерфейса IShipping---\n");
            A.StatusShipping(); //обертывание

            Console.WriteLine("\n---Реализация обертывания метода Status_casting() интерфейса IDrive---\n");
            A.StatusDrive(); //обертывание
            //-----------------------------------------------------------------------------------------------
            //3.Работа с массивом
            //-----------------------------------------------------------------------------------------------
            IDrive[] X = new IDrive[] { new Cars(1.8, "BMW", "E39", 120), new Wagon(7.3, "IVECO", "S-Way", 85, false, false, 0, 0),
                                        new Cars(1.5, "Opel", "Astra", 100), new Wagon(12, "Scania", "R-Series", 72, true, true, 9, 3.5)};
            foreach (IDrive x in X)
            {

                if (x is IShipping)
                { //если в массиве, присутсутют элементы поддерживающие интерфейс IShipping
                    ((IShipping)x).Status_gluing(); //вызов метода из интерфейса IShipping
                }
            }
            //-----------------------------------------------------------------------------------------------
            //4.Использование стандартных интерфейсов
            //-----------------------------------------------------------------------------------------------
            Cars[] CAR = new Cars[] { new Cars(1.8, "BMW", "E39", 120), new Cars(1.5, "Opel", "Astra", 100),
                                      new Cars(2.1, "Audi", "A8", 150), new Cars(1.2, "Volkswagen", "Golf", 110) };

            /*Сортировка, с использованием метода Array.Sort(), и интерфейса IComparable*/
            int i = 1;
            //Объекты массива, до сортировки
            Console.WriteLine("-----------До сортировки-----------");
            foreach (Cars x in CAR)
            {
                Console.WriteLine($"№{i++} - Модель - {x.Mark}");
            }
            i = 1;
            //Сортировка объектов массива, по полю Mark
            Array.Sort(CAR);
            //Объекты массива, после сортировки
            Console.WriteLine("-----------После сортировки-----------");
            foreach (Cars x in CAR)
            {
                Console.WriteLine($"№{i++} - Модель - {x.Mark}");
            }

            /*Сортировка, с использованием метода Array.Sort(), и интерфейса IComparer*/
            i = 1;
            //Объекты массива, после сортировки, по полю Speed
            Console.WriteLine("-----------После сортировки, по полю Speed-----------");
            Array.Sort(CAR, new CarsComparer_Speed()); //
            foreach (Cars x in CAR)
            {
                Console.WriteLine($"№{i++} - Модель - {x.Mark}\t Скорость - {x.Speed} км/ч\t Масса - {x.Weight} т.");
            }
            //Объекты массива, после сортировки, по полю Weight
            i = 1;
            Console.WriteLine("-----------После сортировки, по полю Weight-----------");
            Array.Sort(CAR, new CarsComparer_Weight()); //
            foreach (Cars x in CAR)
            {
                Console.WriteLine($"№{i++} - Модель - {x.Mark}\t Скорость - {x.Speed} км/ч\t Масса - {x.Weight} т.");
            }
            //-----------------------------------------------------------------------------------------------
            //5.Создать класс с именованным итератором, который принимает 2 аргумента – start и end.
            //-----------------------------------------------------------------------------------------------
            Task5 letters = new Task5();
        e:
            Console.WriteLine("Введите диапазон");
            Console.WriteLine("-------------------");
            Console.Write("Start: ");
            int s = Convert.ToInt32(Console.ReadLine());
            Console.Write("End: ");
            int e = Convert.ToInt32(Console.ReadLine());
            if ((e - s) <= 0) { Console.WriteLine("Ошибка ввода."); goto e; }
            if ((e - s) >= 26) { Console.WriteLine("В алфавите всего 26 букв. Введено большее значение."); goto e; }
            Console.WriteLine("-------------------");
            Console.WriteLine("Результат:");
            foreach (char x in letters.Iterator(s, e))
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");
        }
    }
}

