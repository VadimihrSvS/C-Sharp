using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadan_1
{
    interface IShipping //(перевозка груза)
    {
        //свойства 

        bool Cargo { get; set; } //груз (есть/нет)

        double WCargo { get; set; } //масса груза, т

        //методы

        int Add_Cargo(); //добавить груз

        int Del_Cargo(); //удалить груз

        void Status_casting(); //информация о перевозке груза (кастинг)

        void Status_gluing(); //информация о перевозке груза (склеивание)

    }
}
