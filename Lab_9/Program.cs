using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Диограмма Ганта";
            int time = 0;
            int p = 0;
            Task[] gant = new Task[8] // массив задач
            {
            new Task(() => Stage("1) Поиск заказчика       ",4,ref time)),  //название этапа и его продолжительность
            new Task(() => Stage("2) Состовление договора  ",2,ref time)),
            new Task(() => Stage("3) Формирование ТЗ       ",3,ref time)),
            new Task(() => Stage("4) Соглосование ТЗ       ",2,ref time)),
            new Task(() => Stage("5) Разработка проекта    ",15,ref time)),
            new Task(() => Stage("6) Тестирование проекта  ",5,ref time)),
            new Task(() => Stage("7) Доработка проекта     ",3,ref time)),
            new Task(() => Stage("8) Сдача проекта         ",4,ref time))
            };   
            foreach (Task t in gant)
            { 
                t.Start();//запуск задачи
                t.Wait();
            }
            Task.WaitAll(gant);
            Console.WriteLine($"    Завершение проекта. Общая продолжительность {time} дней.");
            Console.Beep();
            static void Stage(string name, int duration, ref int t)//метод для вывода этапа
            {
                Random random = new();
                int durationRan = duration * (100+random.Next(5, 50))/100; //увеличение длительности этапа на 5-50%
                Console.Write($" {name}");
                for (int y = 0; y < t; y++)
                {
                    Console.Write(' ');
                }
                for (int i = 0; i < durationRan; i++)
                {
                    Console.Write("*");              
                    Thread.Sleep(100);
                }
                Console.Write(new String(' ', (55 - durationRan - t)>0 ? (55 - durationRan - t):5));
                Console.Write($"Начало {t+1} день, конец {t+durationRan} день");
                t += durationRan;            
                Console.Write("\n");
            }
        }
    }
}
