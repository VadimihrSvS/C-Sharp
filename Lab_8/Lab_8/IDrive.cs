using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    interface IDrive //(езда)
    {
        //свойства 

        int Speed { get; set; } //скорость

        string status { get; set; } //состояние машины (едет/не едет)

        //методы

        int Start(); //начать движение

        int Stop(); //остановиться

        void Status_casting(); //информация о состоянии движения (кастинг)

        void Status_gluing(); //информация о состоянии движения (склеивание)      

    }
}
