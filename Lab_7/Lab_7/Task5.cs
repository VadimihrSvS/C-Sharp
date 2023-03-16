using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadan_1
{
    //5. создать класс с именованным итератором, который принимает 2 аргумента – start и end.
    //3)	вывод случайных букв в диапазоне от start до end без повтора
    class Task5
    {
        Random g = new Random(); //Объект класса Random, для генерации случайной буквы

        //создание именованного итератора

        public IEnumerable Iterator(int start, int end)
        {
            bool duplicate = false; //флаг сигнализирующий о дублирующейся букве
            char buf_char; //буферная переменная

            char[] buf = new char[end - start]; //буфферный массив
            for (int iter = 0; iter < buf.Length; iter++)
            {
                buf[iter] = (char)g.Next('a', 'z'); //заполнение массива случайными буквами в диапазоне [a...z]
            }

            for (int f = 0; f < buf.Length; f++)
            { //цикл на проверку повторяющихся букв
                while (true) //цикл работает, пока буквы в массиве не будут разными
                {
                    buf_char = buf[f]; //запоминаем букву из массива

                    //это условие обретает смысл, после прохождения следующего вложенного цикла
                    if (duplicate == true) { buf_char = (char)g.Next('a', 'z'); } //если буква повторяется, меняем ее

                    for (int j = 0; j < f; j++) //цикл по "доступной" части массива
                    {

                        if (buf_char == buf[j]) { duplicate = true; break; } //если буква повторилась, поднимается флаг, выход из цикла
                        duplicate = false; //если буква не повторилась, обнуляем флаг(не сделав это, ф-ия зациклится)
                    }

                    if (duplicate == false) { break; } //если буква не повторилась, выходим из "бесконечного" цикла

                }

                buf[f] = buf_char; //кладем букву обратно в массив (т.к не знаем, повторялась ли она или нет)
            }

            for (int i = 0; i < buf.Length; i++)
            {
                yield return buf[i]; //возвращаем итерируемый элемент
            }
        }
    }
}
