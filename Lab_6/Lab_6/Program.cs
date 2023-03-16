using System;

namespace Lab_6
{
    delegate void DELEGAT_void(); //Объявление делегата без параметров

    class Program
    {
        static void Main(string[] args)
        {

            airplane x = new airplane("1F23RA", "BL326", 5000, 100000, 700, 9000, new int[] { 90, 90 }); //объект х класса airplane
            airplane y = new airplane("3M42WL", "FN032", 4500, 110000, 600, 8300, new int[] { 60, 45 }); //объект у класса airplane

            //1.d. Вызов статических методов, анонимного делегата и лямбда-выражения
            Console.WriteLine("1.d. Вызов статических методов, анонимного делегата и лямбда-выражения");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            x.Filling_Delegat(static_method1); //передаем делегату в классе airplane, метод из класса Program
            x.Start_Delegat(); //запускаем делегат
            x.Filling_Delegat(static_method2); //передаем делегату в классе airplane, метод из класса Program
            x.Start_Delegat(); //запускаем делегат
            DELEGAT_void anonim_delegat = delegate () { Console.WriteLine("This text is output by anonymous delegate"); };
            x.Filling_Delegat(anonim_delegat); //передаем делегату в классе airplane, анонимный делегат
            x.Start_Delegat(); //запускаем делегат
            DELEGAT_void lyambda_delegat = () => Console.WriteLine("This text is output by lambda expression");
            x.Filling_Delegat(lyambda_delegat); //передаем делегату в классе airplane, лямбда-выражение
            x.Start_Delegat(); //запускаем делегат

            //1.e.	Создайте групповой делегат.
            DELEGAT_void del_group = static_method1;
            del_group += static_method2;
            del_group += anonim_delegat;
            del_group += lyambda_delegat;

            //1.f.	Сделайте самолет, от которого выводятся все возможные сообщения.
            Console.WriteLine("\n" + "1.f	Сделайте самолет, от которого выводятся все возможные сообщения.");
            Console.WriteLine("---------------------------------------------------------------------------------------");

            y.Filling_Delegat(del_group); //передаем делегату в классе airplane, групповой делегат класса Program
            y.Start_Delegat(); //запускаем делегат

            Console.WriteLine("\n" + "Сравнение делегатов.");
            x.EqualsDel(y); //Метод, который сравнивает поля делегатов двух объектов

            //2.b Аналогично первому заданию создайте метод и вызовите его из Program. 
            Console.WriteLine("\n" + "2. Делегат с параметрами.");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Вызов метода класса Param, через делегат.");
            airplane.DELEGAT_param Delegate_param = acceleration;
            y.Del_param_filling(Delegate_param); //передаем делегату в классе airplane, метод из класса Program
            y.Start_Delegat_param(250); //запуска делегата
            Console.WriteLine();
            Delegate_param = breaking;
            x.Del_param_filling(Delegate_param); //передаем делегату в классе airplane, метод из класса Program
            x.Start_Delegat_param(100); //запуска делегата
            Console.WriteLine("\n" + "Анонимный делегат.");
            airplane.DELEGAT_param Delegate_param_anonim = delegate (airplane q, int w)
            {
                Console.WriteLine("Уменьшение расхода топлива.");
                if ((q.FUEL - w) > 0)
                {
                    Console.WriteLine($"Текущий расход топлива: {q.FUEL} кг/ч");
                    q.FUEL -= w;
                    Console.WriteLine($"Уменьшеный расход топлива: {q.FUEL} кг/ч.");
                }
            };

            x.Del_param_filling(Delegate_param_anonim); //передаем делегату в классе airplane, анонимный делегат
            x.Start_Delegat_param(200); //запускаем делегат

            Console.WriteLine("\n" + "Лямбда-выражение.");
            airplane.DELEGAT_param Delegate_lyambda = (airplane a, int b) => acceleration(a, b);
            x.Del_param_filling(Delegate_lyambda);
            x.Start_Delegat_param(400);

            //3.b
            Console.WriteLine("\n" + "3. События.");
            Console.WriteLine("---------------------------------------------------------------------------------------");
            HandlerSpeed handler = new HandlerSpeed(); //инициализация обработчика

            Console.WriteLine("Объект x");
            x.ESpeed += handler.min_speed; //подписка на событие(в случае его возникновения, обрабатываем соответствующим методом)
            x.Breaking(950); //останавливаем самолет
            x.ESpeed -= handler.min_speed; //отписка от события, по минимальной скорости
            x.ESpeed += handler.max_speed; //подписка на событие(в случае его возникновения, обрабатываем соответствующим методом)
            x.Accelerate(950); //максимально ускоряем самолет

            HandlerHeight handlerHeight = new HandlerHeight(); //инициализация объекта класса-обработчика события.
            var smth_Var = 500; //переменная, на которую меняем высоту

            //обработчик события - статический метод класса Program.
            y.EHeight += StaticHandler;

            //обработчик события - экземплярный метод собственного класса.
            y.EHeight += y.Handler;

            //обработчик события, метод класса - обработчика.
            y.EHeight += handlerHeight.ClassHandler_height;

            //обработчик события, анонимный делегат.
            y.EHeight += delegate (airplane a, int b) { b = smth_Var; return string.Format($"Высота самолета {a.BOARD}, уменьшилась на {b} м."); };

            //обработчик события, лямбда-выражение
            y.EHeight += (airplane q, int a) => { a = smth_Var; return string.Format($"Высота самолета {q.BOARD}, уменьшилась на {a} м."); };

            Console.WriteLine("\n" + "Объект y");
            y.decreaseHeight(smth_Var); //уменьшаем высоту полета объекта y, вследствие чего происходит событие которое регистрирует изменение высоты

            Console.ReadKey();
        }

        //Статические методы, на которые будет указывать делегат
        static void static_method1()
        {
            Console.WriteLine("This is a airplane.");
        }

        static void static_method2()
        {
            Console.WriteLine("This plane is flying very high.");
        }

        static void acceleration(airplane x, int sp)
        {
            Console.WriteLine("Ускорение.");
            if ((x.SPEED + sp) < 950)
            {
                Console.WriteLine($"Текущая скорость самолета: {x.SPEED} км/ч.");
                x.SPEED += sp;
                Console.WriteLine($"Скорость, после ускорения: {x.SPEED} км/ч.");
            }
            else { x.SPEED = 950; Console.WriteLine($"Скорость самолета максимальна: {x.SPEED} км/ч."); }
        }

        static void breaking(airplane x, int sp)
        {
            Console.WriteLine("Торможение.");
            if ((x.SPEED - sp) > 0)
            {
                Console.WriteLine($"Текущая скорость самолета: {x.SPEED} км/ч.");
                x.SPEED -= sp;
                Console.WriteLine($"Скорость, после ускорения: {x.SPEED} км/ч.");
            }
            else { x.SPEED = 0; Console.WriteLine($"Скорость самолета минимальна: {x.SPEED} км/ч."); }
        }

        static void messege()
        {
            Console.WriteLine("Достигнута максимальная скорость!");
        }

        //3 задание, статический метод.
        static string StaticHandler(airplane x, int b)
        {
            return string.Format("Самолет - {0}, изменил высоту на - {1} м.", x.BOARD, b);
        }

    }
}
