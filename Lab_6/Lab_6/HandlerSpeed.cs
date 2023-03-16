using System;

namespace Lab_6
{
    //3.b Класс обработчик события, по скорости
    class HandlerSpeed
    {
        public void max_speed()
        { //если скорость самолета максимальна           
            Console.WriteLine("Самолет развил максимальную скорость!");
        }

        public void min_speed()
        { //если скорость самолета минимальна 
            Console.WriteLine("Самолет стоит на взлетой полосе!");
        }
    }
}
