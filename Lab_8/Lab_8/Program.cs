using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    class main
    {
        static void menu()
        {
            Console.WriteLine("----------------Меню----------------");
            Console.WriteLine("1. Просмотр коллекции.");
            Console.WriteLine("2. Добавление элемента.");
            Console.WriteLine("3. Добавление элемента по указанному индексу.");
            Console.WriteLine("4. Нахождение элемента с начала коллекции (по полю - mark).");
            Console.WriteLine("5. Нахождение элемента с конца коллекции.");
            Console.WriteLine("6. Удаление элемента по индексу.");
            Console.WriteLine("7. Удаление элемента по значению.");
            Console.WriteLine("8. Реверс коллекции.");
            Console.WriteLine("9. Сортировка.");
            Console.WriteLine("10. Выполнение методов всех объектов, поддерживающих Interface2.");
            Console.WriteLine("11. Вызов меню.");
            Console.WriteLine("0. Выход из программы.");
            Console.WriteLine("------------------------------------");
        }
        static void method1(ArrayList x)
        {
            int i = 0;
            Console.WriteLine($"Индекс\t|\tЭлемент");
            Console.WriteLine("------------------------------------");
            foreach (object a in x)
            {
                Console.WriteLine($"[{i}]\t|\t{a.ToString()}");
                i++;
            }
            Console.WriteLine("------------------------------------");
        }//1. Просмотр коллекции.
        static void method2(ArrayList x)
        {
            Console.WriteLine("\tКакой элемент вы хотите добавить в коллекцию?");
            EnumerationTypes();
            Console.Write("Выбор:  ");
            string str = Console.ReadLine();
            int num;
            if (Int32.TryParse(str, out num) == false)
            {
                Console.WriteLine("------------------------------------");
                return;
            }
            switch (num)
            {
                case 1:
                    {
                        Console.Write("Введите строку:  ");
                        x.Add(Console.ReadLine());
                        break;
                    }
                case 2:
                    {
                        Console.Write("Введите целое число:  ");
                        string h = Console.ReadLine();
                        int z;
                        if (Int32.TryParse(h, out z) == false) { Console.WriteLine("\tОшибка ввода."); break; }
                        x.Add(z);
                        break;
                    }
                case 3:
                    {
                        Cars c = new Cars();
                        Console.Write("\tВведите марку автомобиля: ");
                        string mr = Console.ReadLine();
                        c.Mark = mr;
                        Console.Write("\n\tВведите модель автомобиля: ");
                        string md = Console.ReadLine();
                        c.Model = md;
                    mas:
                        Console.Write("\n\tВведите массу автомобиля: ");
                        string mas = Console.ReadLine();
                        double weight;
                        if (Double.TryParse(mas, out weight) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto mas;
                        }
                        c.Weight = weight;
                    speed:
                        Console.Write("\n\tВведите скорость автомобиля: ");
                        string sp = Console.ReadLine();
                        int speed;
                        if (Int32.TryParse(sp, out speed) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto speed;
                        }
                        c.Speed = speed;
                        x.Add(c);
                        break;
                    }
                case 4:
                    {
                        Cars c = new Wagon();
                        Console.Write("\tВведите марку фуры: ");
                        string mr = Console.ReadLine();
                        c.Mark = mr;
                        Console.Write("\n\tВведите модель фуры: ");
                        string md = Console.ReadLine();
                        c.Model = md;
                    mas:
                        Console.Write("\n\tВведите массу фуры: ");
                        string mas = Console.ReadLine();
                        double weight;
                        if (Double.TryParse(mas, out weight) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto mas;
                        }
                        c.Weight = weight;
                    speed:
                        Console.Write("\n\tВведите скорость фуры: ");
                        string sp = Console.ReadLine();
                        int speed;
                        if (Int32.TryParse(sp, out speed) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto speed;
                        }
                        c.Speed = speed;
                    trailer:
                        Console.Write("\n\tЕсть прицеп? [Y/N]: ");
                        string tr = Console.ReadLine();
                        bool trailer;
                        if (tr == "Y" || tr == "y" || tr == "N" || tr == "n")
                        {
                            if (tr != "N" && tr != "n") { trailer = true; }
                            else { trailer = false; }
                        }
                        else { Console.WriteLine("\tОшибка ввода."); goto trailer; }
                        ((c as Wagon).Trailer) = trailer;
                        if (trailer == false) { x.Add(c); break; } //если нет прицепа, то нет и груза (выходим)
                    WT:
                        Console.Write("\n\tВведите массу прицепа: ");
                        string wt = Console.ReadLine();
                        double weight_trailer;
                        if (Double.TryParse(wt, out weight_trailer) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto WT;
                        }
                        ((c as Wagon).WTrailer) = weight_trailer;
                    cargo:
                        Console.Write("\n\tЕсть груз? [Y/N]: ");
                        string cr = Console.ReadLine();
                        bool cargo;
                        if (cr == "Y" || cr == "y" || cr == "N" || cr == "n")
                        {
                            if (cr != "N" && cr != "n") { cargo = true; }
                            else { cargo = false; }
                        }
                        else { Console.WriteLine("\tОшибка ввода."); goto cargo; }
                        ((c as Wagon).Cargo) = cargo;
                        if (cargo == false) { x.Add(c); break; } //если нет груза, то нет и его массы (выходим)
                    WC:
                        Console.Write("\n\tВведите массу груза: ");
                        string wc = Console.ReadLine();
                        double weight_cargo;
                        if (Double.TryParse(wc, out weight_cargo) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto WC;
                        }
                        ((c as Wagon).WCargo) = weight_cargo;

                        x.Add(c);
                        break;
                    }
                default: break;
            }
            Console.WriteLine("------------------------------------");
        }//2. Добавление элемента.       
        static void method3(ArrayList x)
        {
        begin:
            try
            {
                Console.Write("\tВведите индекс, по которому, вы хотите добавить элемент:  ");
                string ind = Console.ReadLine();
                int index;
                if (Int32.TryParse(ind, out index) == false)
                {
                    Console.WriteLine("\tОшибка ввода.");
                    return;
                }
                if (index < 0) { Console.WriteLine("\tИндекс не может быть отрицательным!"); goto begin; }

                Console.WriteLine("\tКакой элемент вы хотите добавить в коллекцию?");
                EnumerationTypes();
                Console.Write("Выбор:  ");
                string str = Console.ReadLine();
                int num;
                if (Int32.TryParse(str, out num) == false)
                {
                    Console.WriteLine("\tОшибка ввода.");
                    return;
                }
                switch (num)
                {
                    case 1:
                        {
                            Console.Write("Введите строку:  ");
                            x.Insert(index, Console.ReadLine());
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Введите целое число:  ");
                            string h = Console.ReadLine();
                            int z;
                            if (Int32.TryParse(h, out z) == false)
                            {
                                Console.WriteLine("\tОшибка ввода.");
                                return;
                            }
                            x.Insert(index, z);
                            break;
                        }
                    case 3:
                        {
                            Cars c = new Cars();
                            Console.Write("\tВведите марку автомобиля: ");
                            string mr = Console.ReadLine();
                            c.Mark = mr;
                            Console.Write("\n\tВведите модель автомобиля: ");
                            string md = Console.ReadLine();
                            c.Model = md;
                        mas:
                            Console.Write("\n\tВведите массу автомобиля: ");
                            string mas = Console.ReadLine();
                            double weight;
                            if (Double.TryParse(mas, out weight) == false)
                            {
                                Console.WriteLine("\tОшибка ввода.");
                                goto mas;
                            }
                            c.Weight = weight;
                        speed:
                            Console.Write("\n\tВведите скорость автомобиля: ");
                            string sp = Console.ReadLine();
                            int speed;
                            if (Int32.TryParse(mas, out speed) == false)
                            {
                                Console.WriteLine("\tОшибка ввода.");
                                goto speed;
                            }
                            c.Speed = speed;
                            x.Insert(index, c);
                            break;
                        }
                    case 4:
                        {
                            Cars c = new Wagon();
                            Console.Write("\tВведите марку фуры: ");
                            string mr = Console.ReadLine();
                            c.Mark = mr;
                            Console.Write("\n\tВведите модель фуры: ");
                            string md = Console.ReadLine();
                            c.Model = md;
                        mas:
                            Console.Write("\n\tВведите массу фуры: ");
                            string mas = Console.ReadLine();
                            double weight;
                            if (Double.TryParse(mas, out weight) == false)
                            {
                                Console.WriteLine("\tОшибка ввода.");
                                goto mas;
                            }
                            c.Weight = weight;
                        speed:
                            Console.Write("\n\tВведите скорость фуры: ");
                            string sp = Console.ReadLine();
                            int speed;
                            if (Int32.TryParse(mas, out speed) == false)
                            {
                                Console.WriteLine("\tОшибка ввода.");
                                goto speed;
                            }
                            c.Speed = speed;
                        trailer:
                            Console.Write("\n\tЕсть прицеп? [Y/N]: ");
                            string tr = Console.ReadLine();
                            bool trailer;
                            if (tr == "Y" || tr == "y" || tr == "N" || tr == "n")
                            {
                                if (tr != "N" && tr != "n") { trailer = true; }
                                else { trailer = false; }
                            }
                            else { Console.WriteLine("\tОшибка ввода."); goto trailer; }
                            ((c as Wagon).Trailer) = trailer;
                            if (trailer == false) { x.Add(c); break; } //если нет прицепа, то нет и груза (выходим)
                        WT:
                            Console.Write("\n\tВведите массу прицепа: ");
                            string wt = Console.ReadLine();
                            double weight_trailer;
                            if (Double.TryParse(wt, out weight_trailer) == false)
                            {
                                Console.WriteLine("\tОшибка ввода.");
                                goto WT;
                            }
                            ((c as Wagon).WTrailer) = weight_trailer;
                        cargo:
                            Console.Write("\n\tЕсть груз? [Y/N]: ");
                            string cr = Console.ReadLine();
                            bool cargo;
                            if (cr == "Y" || cr == "y" || cr == "N" || cr == "n")
                            {
                                if (cr != "N" && cr != "n") { cargo = true; }
                                else { cargo = false; }
                            }
                            else { Console.WriteLine("\tОшибка ввода."); goto cargo; }
                            ((c as Wagon).Cargo) = cargo;
                            if (cargo == false) { x.Add(c); break; } //если нет груза, то нет и его массы (выходим)
                        WC:
                            Console.Write("\n\tВведите массу груза: ");
                            string wc = Console.ReadLine();
                            double weight_cargo;
                            if (Double.TryParse(wt, out weight_cargo) == false)
                            {
                                Console.WriteLine("\tОшибка ввода.");
                                goto WC;
                            }
                            ((c as Wagon).WCargo) = weight_cargo;

                            x.Insert(index, c);
                            break;
                        }
                    default: break;
                }
                Console.WriteLine("------------------------------------");
            }
            catch (System.ArgumentOutOfRangeException)
            {
                Console.WriteLine("\tИндекс лежит за диапазоном!");
                Console.WriteLine("\tЭлемент не может быть добавлен...");
            }
        }//3. Добавление элемента по указанному индексу.
        static void method4(ArrayList x)
        {
            Console.Write("\tВведите марку автомобиля:  ");
            string mark = Console.ReadLine();
            Cars obj = new Cars(mark);
            int index = x.IndexOf(obj);
            if (index == -1)
            {
                Console.WriteLine("\tТакого элемента в коллекции нет.");
            }
            else
            {
                Console.WriteLine($"\tИндекс вашего элемента - [{index}]");
            }
            Console.WriteLine("------------------------------------");
        }//4. Нахождение элемента с начала коллекции (по полю - mark).
        static void method5(ArrayList x)
        {
            Console.Write("\tВведите марку автомобиля:  ");
            string mark = Console.ReadLine();
            Cars obj = new Cars(mark);
            int index = x.LastIndexOf(obj);
            if (index == -1)
            {
                Console.WriteLine("\tТакого элемента в коллекции нет.");
            }
            else
            {
                Console.WriteLine($"\tИндекс вашего элемента - [{index}]");
            }
            Console.WriteLine("------------------------------------");
        }//5. Нахождение элемента с конца коллекции (по полю - mark).
        static void method6(ArrayList x)
        {
            Console.Write("\tВведите индекс элемента:  ");
            string ind = Console.ReadLine();
            int index;
            int i = 0;
            if (Int32.TryParse(ind, out index) == false) { Console.WriteLine("\tОшибка ввода."); }
            else
            {
                foreach (object xxx in x) { i++; }
                if (index < 0 || index > i) { Console.WriteLine("\tНеверный ввод. Индекс находится за границей коллекции."); }
                else
                {
                    x.RemoveAt(index);
                    Console.WriteLine($"\tЭлемент по индексу [{index}], успешно удален.");
                }
            }
            Console.WriteLine("------------------------------------");
        }//6. Удаление элемента по индексу.
        static void method7(ArrayList x)
        {
            Console.Write("\tВведите марку автомобиля:  ");
            string mark = Console.ReadLine();
            Cars obj = new Cars(mark);
            foreach (object xxx in x)
            {
                if ((xxx as Cars)?.Mark == obj.Mark)
                {
                    x.Remove((xxx as Cars));
                    Console.WriteLine($"\tЭлемент {mark} успешно удален из коллекции.");
                    Console.WriteLine("------------------------------------");
                    return;
                }
            }
            Console.WriteLine("\tТакого элемента в коллекции нет.");
            Console.WriteLine("------------------------------------");
        }//7. Удаление элемента по значению.
        static void method8(ArrayList x)
        {
            x.Reverse();
            Console.WriteLine("\tКоллекция перевернута.");
            Console.WriteLine("------------------------------------");
        }//8. Реверс коллекции.
        static void method9(ArrayList x)
        {
            foreach (object xxx in x)
            {
                if ((xxx as Cars) == null)
                {
                    Console.WriteLine("\tКоллекция не отсортирована, т.к присутсвуют элементы разных типов.");
                    Console.WriteLine("------------------------------------");
                    return;
                }
            }
            x.Sort();
            Console.WriteLine("\tКоллекция успешно отсортирована.");
            Console.WriteLine("------------------------------------");
        }//9. Сортировка.
        static void method10(ArrayList x)
        {
            string str;
            /*foreach (object z in x) {
                string info = (z is Cars) ? (z as Cars)?.GetInfo() : (z as Wagon)?.GetInfo();
                Console.WriteLine(info);
            }*/
            //Console.WriteLine("___________________________________");
            foreach (object xxx in x)
            {
                if (xxx is IShipping)
                {
                    Console.WriteLine((xxx as Wagon)?.GetInfo());

                    if ((xxx as IShipping).Add_Cargo() == 0)
                    {
                        Console.WriteLine("\tФура загружена.");
                    }
                    else if ((xxx as IShipping).Add_Cargo() == -1)
                    {
                        Console.Write("\tДля перевозки груза необходим прицеп.\n");
                    }
                    else
                    {
                        Console.WriteLine("\tФура уже перевозит груз.");
                    }

                del:
                    Console.Write("\tРазгрузить фуру? [Y/N]:  ");
                    str = Console.ReadLine();
                    if (str == "Y" || str == "y")
                    {
                        if ((xxx as IShipping).Del_Cargo() == 0)
                        {
                            Console.Write("\tФура разгружена.");
                        }
                        else
                        {
                            Console.Write("\tФура не перевозит груз.\n");
                        }
                    }
                    else if (str == "N" || str == "n") { }
                    else
                    {
                        Console.WriteLine("\tОшибка ввода.");
                        goto del;
                    }

                    (xxx as IShipping).Status_gluing();

                    Console.WriteLine("______________________________________");
                }
            }
            Console.WriteLine("------------------------------------");
        }//10. Выполнение методов всех объектов, поддерживающих Interface2.

        static void EnumerationTypes()
        {
            Console.WriteLine("\t1 - Строка");
            Console.WriteLine("\t2 - Целое число");
            Console.WriteLine("\t3 - Автомобиль");
            Console.WriteLine("\t4 - Фура");
            Console.WriteLine("\tОтказ - любая другая клавиша");
        }
        static void method1_LinkedList(LinkedList<Cars> x)
        {
            int i = 0;
            Console.WriteLine($"№\t|\tЭлемент");
            Console.WriteLine("------------------------------------");
            foreach (object a in x)
            {
                Console.WriteLine($"{i}\t|\t{a.ToString()}");
                i++;
            }
            Console.WriteLine("------------------------------------");
        }//1. Просмотр связного списка.
        static void method2_LinkedList(LinkedList<Cars> x)
        {
            Console.WriteLine("\tКакой элемент вы хотите добавить в список?");
            EnumerationTypes_LinkedList();
            Console.Write("\tВыбор:  ");
            string str = Console.ReadLine();
            int num;
            if (Int32.TryParse(str, out num) == false)
            {
                Console.WriteLine("------------------------------------");
                return;
            }
            switch (num)
            {
                case 1:
                    {
                        Cars c = new Cars();
                        Console.Write("\tВведите марку автомобиля: ");
                        string mr = Console.ReadLine();
                        c.Mark = mr;
                        Console.Write("\n\tВведите модель автомобиля: ");
                        string md = Console.ReadLine();
                        c.Model = md;
                    mas:
                        Console.Write("\n\tВведите массу автомобиля: ");
                        string mas = Console.ReadLine();
                        double weight;
                        if (Double.TryParse(mas, out weight) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto mas;
                        }
                        c.Weight = weight;
                    speed:
                        Console.Write("\n\tВведите скорость автомобиля: ");
                        string sp = Console.ReadLine();
                        int speed;
                        if (Int32.TryParse(mas, out speed) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto speed;
                        }
                        c.Speed = speed;
                        x.AddLast(c);
                        break;
                    }
                case 2:
                    {
                        Cars c = new Wagon();
                        Console.Write("\tВведите марку фуры: ");
                        string mr = Console.ReadLine();
                        c.Mark = mr;
                        Console.Write("\n\tВведите модель фуры: ");
                        string md = Console.ReadLine();
                        c.Model = md;
                    mas:
                        Console.Write("\n\tВведите массу фуры: ");
                        string mas = Console.ReadLine();
                        double weight;
                        if (Double.TryParse(mas, out weight) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto mas;
                        }
                        c.Weight = weight;
                    speed:
                        Console.Write("\n\tВведите скорость фуры: ");
                        string sp = Console.ReadLine();
                        int speed;
                        if (Int32.TryParse(mas, out speed) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto speed;
                        }
                        c.Speed = speed;
                    trailer:
                        Console.Write("\n\tЕсть прицеп? [Y/N]: ");
                        string tr = Console.ReadLine();
                        bool trailer;
                        if (tr == "Y" || tr == "y" || tr == "N" || tr == "n")
                        {
                            if (tr != "N" && tr != "n") { trailer = true; }
                            else { trailer = false; }
                        }
                        else { Console.WriteLine("\tОшибка ввода."); goto trailer; }
                        ((c as Wagon).Trailer) = trailer;
                        if (trailer == false) { x.AddLast(c); break; } //если нет прицепа, то нет и груза (выходим)
                    WT:
                        Console.Write("\n\tВведите массу прицепа: ");
                        string wt = Console.ReadLine();
                        double weight_trailer;
                        if (Double.TryParse(wt, out weight_trailer) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto WT;
                        }
                        ((c as Wagon).WTrailer) = weight_trailer;
                    cargo:
                        Console.Write("\n\tЕсть груз? [Y/N]: ");
                        string cr = Console.ReadLine();
                        bool cargo;
                        if (cr == "Y" || cr == "y" || cr == "N" || cr == "n")
                        {
                            if (cr != "N" && cr != "n") { cargo = true; }
                            else { cargo = false; }
                        }
                        else { Console.WriteLine("\tОшибка ввода."); goto cargo; }
                        ((c as Wagon).Cargo) = cargo;
                        if (cargo == false) { x.AddLast(c); break; } //если нет груза, то нет и его массы (выходим)
                    WC:
                        Console.Write("\n\tВведите массу груза: ");
                        string wc = Console.ReadLine();
                        double weight_cargo;
                        if (Double.TryParse(wt, out weight_cargo) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto WC;
                        }
                        ((c as Wagon).WCargo) = weight_cargo;

                        x.AddLast(c);
                        break;
                    }
                default: break;
            }
            Console.WriteLine("------------------------------------");
        }//2. Добавление элемента в связный список.
        static void method3_LinkedList(LinkedList<Cars> x)
        {
        s:
            Console.Write("\tВведите позицию, в которую хотите вставить элемент, начиная с 0:  ");
            string p = Console.ReadLine();
            int pos;
            if (Int32.TryParse(p, out pos) == false) { Console.WriteLine("\tОшибка ввода."); return; }

            if (pos < 0 || pos >= x.Count)
            {
                Console.WriteLine("\tПозиция не может быть отрицательной и выходить за границу списка.");
                goto s;
            }

            Console.WriteLine("\tКакой элемент вы хотите добавить в список?");
            EnumerationTypes_LinkedList();
            Console.Write("\tВыбор:  ");
            string str = Console.ReadLine();
            int num;
            if (Int32.TryParse(str, out num) == false)
            {
                Console.WriteLine("------------------------------------");
                return;
            }
            Cars c = new Cars();
            switch (num)
            {
                case 1:
                    {
                        Console.Write("\tВведите марку автомобиля: ");
                        string mr = Console.ReadLine();
                        c.Mark = mr;
                        Console.Write("\n\tВведите модель автомобиля: ");
                        string md = Console.ReadLine();
                        c.Model = md;
                    mas:
                        Console.Write("\n\tВведите массу автомобиля: ");
                        string mas = Console.ReadLine();
                        double weight;
                        if (Double.TryParse(mas, out weight) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto mas;
                        }
                        c.Weight = weight;
                    speed:
                        Console.Write("\n\tВведите скорость автомобиля: ");
                        string sp = Console.ReadLine();
                        int speed;
                        if (Int32.TryParse(sp, out speed) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto speed;
                        }
                        c.Speed = speed;
                        break;
                    }
                case 2:
                    {
                        c = new Wagon();
                        Console.Write("\tВведите марку фуры: ");
                        string mr = Console.ReadLine();
                        c.Mark = mr;
                        Console.Write("\n\tВведите модель фуры: ");
                        string md = Console.ReadLine();
                        c.Model = md;
                    mas:
                        Console.Write("\n\tВведите массу фуры: ");
                        string mas = Console.ReadLine();
                        double weight;
                        if (Double.TryParse(mas, out weight) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto mas;
                        }
                        c.Weight = weight;
                    speed:
                        Console.Write("\n\tВведите скорость фуры: ");
                        string sp = Console.ReadLine();
                        int speed;
                        if (Int32.TryParse(sp, out speed) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto speed;
                        }
                        c.Speed = speed;
                    trailer:
                        Console.Write("\n\tЕсть прицеп? [Y/N]: ");
                        string tr = Console.ReadLine();
                        bool trailer;
                        if (tr == "Y" || tr == "y" || tr == "N" || tr == "n")
                        {
                            if (tr != "N" && tr != "n") { trailer = true; }
                            else { trailer = false; }
                        }
                        else { Console.WriteLine("\tОшибка ввода."); goto trailer; }
                        ((c as Wagon).Trailer) = trailer;
                        if (trailer == false) { break; } //если нет прицепа, то нет и груза (выходим)
                    WT:
                        Console.Write("\n\tВведите массу прицепа: ");
                        string wt = Console.ReadLine();
                        double weight_trailer;
                        if (Double.TryParse(wt, out weight_trailer) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto WT;
                        }
                        ((c as Wagon).WTrailer) = weight_trailer;
                    cargo:
                        Console.Write("\n\tЕсть груз? [Y/N]: ");
                        string cr = Console.ReadLine();
                        bool cargo;
                        if (cr == "Y" || cr == "y" || cr == "N" || cr == "n")
                        {
                            if (cr != "N" && cr != "n") { cargo = true; }
                            else { cargo = false; }
                        }
                        else { Console.WriteLine("\tОшибка ввода."); goto cargo; }
                        ((c as Wagon).Cargo) = cargo;
                        if (cargo == false) { break; } //если нет груза, то нет и его массы (выходим)
                    WC:
                        Console.Write("\n\tВведите массу груза: ");
                        string wc = Console.ReadLine();
                        double weight_cargo;
                        if (Double.TryParse(wt, out weight_cargo) == false)
                        {
                            Console.WriteLine("\tОшибка ввода.");
                            goto WC;
                        }
                        ((c as Wagon).WCargo) = weight_cargo;
                        break;
                    }
                default: break;
            }

            LinkedListNode<Cars> pt = (x as LinkedList<Cars>).First; //указатель по списку 

            for (int i = 0; i < x.Count; i++)
            {
                if (pos == 0 && pos == i) { x.AddFirst(c); break; } //если ввели позицию 0
                if (i == pos - 1)
                {
                    x.AddAfter(pt, c); //вставляем элемент в список
                    break;
                }
                pt = pt.Next; //пробегаем по списку указателем
            }

            Console.WriteLine("------------------------------------");
        }//3. Добавление элемента по указанной позиции. 
        static void method4_LinkedList(LinkedList<Cars> x)
        {
            Console.Write("\tВведите марку автомобиля:  ");
            string mark = Console.ReadLine();
            Cars obj = new Cars(mark);
            LinkedListNode<Cars> z = x.Find(obj);
            LinkedListNode<Cars> pt = x.First; //указатель по списку
            Cars buf;
            if (z != null)
            {
                //Console.WriteLine($"Позиция вашего элемента: {[]}");
                for (int i = 0; i < x.Count; i++)
                {
                    buf = pt.Value; //помещаем в "буфер" данные по указателю
                    if (buf.Mark == obj.Mark)
                    {
                        Console.WriteLine($"\tПозиция вашего элемента: {i}");
                        break;
                    }
                    pt = pt.Next; //пробегаем по списку указателем
                }
            }
            else
            {
                Console.WriteLine("\tТакого элемента в списке нет.");
            }
            Console.WriteLine("------------------------------------");
        }//4. Нахождение элемента с начала связного списка (по полю - mark).
        static void method5_LinkedList(LinkedList<Cars> x)
        {
            Console.Write("\tВведите марку автомобиля:  ");
            string mark = Console.ReadLine();
            Cars obj = new Cars(mark);
            LinkedListNode<Cars> z = x.FindLast(obj); //получаем узел последнего вхождения объекта obj
            LinkedListNode<Cars> pt = x.First; //указатель по списку
            Cars buf;
            int k = 0; //счетчик одинаковых элементов по полю Mark
            if (z != null)
            {
                //Console.WriteLine($"Позиция вашего элемента: {[]}");
                for (int i = 0; i < x.Count; i++)
                {
                    buf = pt.Value; //помещаем в "буфер" данные по указателю
                    if (buf.Mark == obj.Mark)
                    {
                        k++;
                    }
                    pt = pt.Next; //пробегаем по списку указателем
                }
                if (k > 1)
                {
                    for (int i = x.Count - 1; i != 0; i--)
                    {
                        k--; //декрементируем счетчик
                        if (k == 0) { Console.WriteLine($"\tПозиция вашего элемента: {i}"); break; }
                    }
                }
                else
                {
                    pt = x.First;
                    for (int i = 0; i < x.Count; i++)
                    {
                        buf = pt.Value; //помещаем в "буфер" данные по указателю
                        if (buf.Mark == obj.Mark) { Console.WriteLine($"\tПозиция вашего элемента: {i}"); break; }
                        pt = pt.Next; //пробегаем по списку указателем
                    }
                }
            }
            else
            {
                Console.WriteLine("\tТакого элемента в списке нет.");
            }
            Console.WriteLine("------------------------------------");
        }//5. Нахождение элемента с конца связного списка (по полю - mark).
        static void method6_LinkedList(LinkedList<Cars> x)
        {
            int pos;
        e:
            Console.Write("\tВведите позицию элемента, который хотите удалить(начиная с 0):  ");
            string p = Console.ReadLine();
            if (Int32.TryParse(p, out pos) == false)
            {
                Console.WriteLine("\tОшибка ввода.");
                goto e;
            }
            if (pos < 0 || pos >= x.Count)
            {
                Console.WriteLine("\tПозиция не может быть отрицательной и выходить за границу списка.");
                goto e;
            }
            LinkedListNode<Cars> pt = x.First;
            for (int i = 0; i < x.Count; i++)
            {
                if (pos == i)
                {
                    x.Remove(pt);
                    Console.WriteLine($"\tЭлемент, позиции - {i}, успешно удален.");
                    break;
                }
                pt = pt.Next;
            }
            Console.WriteLine("------------------------------------");
        }//6. Удаление элемента по позиции в связном списке.
        static void method7_LinkedList(LinkedList<Cars> x)
        {
            Console.Write("\tВведите марку автомобиля:  ");
            string mark = Console.ReadLine();
            Cars obj = new Cars(mark);
            LinkedListNode<Cars> pt = x.First;
            Cars buf = new Cars();
            for (int i = 0; i < x.Count; i++)
            {
                if (obj.Mark == pt.Value.Mark)
                {
                    x.Remove(pt);
                    Console.WriteLine($"\tЭлемент по полю Mark - {mark}, успешно удален.");
                    Console.WriteLine("------------------------------------");
                    return;
                }
                pt = pt.Next;
            }
            Console.WriteLine("\tТакого элемента в списке нет.");
            Console.WriteLine("------------------------------------");
        }//7. Удаление элемента по значению.
        static void method8_LinkedList(ref LinkedList<Cars> x)
        {
            LinkedList<Cars> buf = new LinkedList<Cars>(); //буфферный список
            LinkedListNode<Cars> pt = x.Last; //указатель с конца списка
            while (pt != null)
            { //пока указатель на что-то указывает
                buf.AddLast(pt.Value); //добавляем значение по указателю в конец буферного списка
                pt = pt.Previous; //перемещаемся от конца списка
            }
            x = buf; //присваиваем ссылку на буферный список, ссылке на исходный список
            Console.WriteLine("\tСписок успешно развёрнут.");
            Console.WriteLine("------------------------------------");
        }//8. Реверс двусвязного списка.
        static void method9_LinkedList(ref LinkedList<Cars> x)
        {
            LinkedListNode<Cars> pt = x.First; //указатель на начало списка
            int i = 0;
            foreach (object xxx in x)
            {
                i++;
            }
            Cars[] mas = new Cars[i];
            /*Переписывание данных из списка в массив*/
            for (i = 0; i < mas.Length; i++)
            {
                mas[i] = pt.Value;
                if (pt.Next != null)
                {
                    pt = pt.Next;
                }
                else { break; }
            }
            Array.Sort(mas);
            /*Переписываем отсортированные данные из массива в список*/
            LinkedList<Cars> new_x = new LinkedList<Cars>();
            for (i = 0; i < mas.Length; i++)
            {
                new_x.AddLast(mas[i]);
            }
            x = new_x;
            Console.WriteLine("\tСписок успешно отсортирован.");
            Console.WriteLine("------------------------------------");
        }//9. Сортировка.
        static void method10_LinkedList(LinkedList<Cars> x)
        {
            string str;
            foreach (object xxx in x)
            {
                if (xxx is IShipping)
                {
                    Console.WriteLine((xxx as Wagon)?.GetInfo());

                    if ((xxx as IShipping).Add_Cargo() == 0)
                    {
                        Console.WriteLine("\tФура загружена.");
                    }
                    else if ((xxx as IShipping).Add_Cargo() == -1)
                    {
                        Console.Write("\tДля перевозки груза необходим прицеп.\n");
                    }
                    else
                    {
                        Console.WriteLine("\tФура уже перевозит груз.");
                    }

                del:
                    Console.Write("\tРазгрузить фуру? [Y/N]:  ");
                    str = Console.ReadLine();
                    if (str == "Y" || str == "y")
                    {
                        if ((xxx as IShipping).Del_Cargo() == 0)
                        {
                            Console.Write("\tФура разгружена.");
                        }
                        else
                        {
                            Console.Write("\tФура не перевозит груз.\n");
                        }
                    }
                    else if (str == "N" || str == "n") { }
                    else
                    {
                        Console.WriteLine("\tОшибка ввода.");
                        goto del;
                    }

                    (xxx as IShipping).Status_gluing();

                    Console.WriteLine("______________________________________");
                }
            }
            Console.WriteLine("------------------------------------");
        }//10. Выполнение методов всех объектов, поддерживающих Interface2.

        static void EnumerationTypes_LinkedList()
        {
            Console.WriteLine("\t1 - Автомобиль");
            Console.WriteLine("\t2 - Фура");
            Console.WriteLine("\tОтказ - любая другая клавиша");
        }

        static int method<type>(type[] array)
        {
            int i = 0;
            foreach (object x in array)
            {
                if (x != null) { i++; }
            }
            return i;
        }
        static void Main(string[] args)
        {
            //-----------------------------------------------------------------------------------------------
            //1.Использование коллекции ArrayList
            //-----------------------------------------------------------------------------------------------
            ArrayList x = new ArrayList() { new Wagon(3.5, "Volvo", "S60", 58, true, true, 4.2, 4.2),
                                            new Cars(2.1, "Audi", "A8", 150),
                                            new Cars(1.7, "Opel", "Vectra", 120),
                                            new Cars(1.8, "BMW", "E39", 120),
                                            new Wagon(7.3, "IVECO", "S-Way", 85, false, false, 0, 0),
                                            new Cars(1.5, "Opel", "Astra", 100),
                                            new Wagon(12, "Scania", "R-Series", 72, true, false, 9, 3.5) };
            menu();
        _b:
            while (true)
            {
                Console.Write("Выберите пункт меню:  ");
                string str = Console.ReadLine();
                Console.WriteLine("------------------------------------");
                int num;
                if (Int32.TryParse(str, out num) == false)
                {
                    Console.WriteLine("Неверный ввод.");
                    Console.WriteLine("------------------------------------");
                    goto _b;
                }
                switch (num)
                {
                    case 0: break;
                    case 1: { method1(x); break; }
                    case 2: { method2(x); break; }
                    case 3: { method3(x); break; }
                    case 4: { method4(x); break; }
                    case 5: { method5(x); break; }
                    case 6: { method6(x); break; }
                    case 7: { method7(x); break; }
                    case 8: { method8(x); break; }
                    case 9: { method9(x); break; }
                    case 10: { method10(x); break; }
                    case 11: { menu(); break; }
                    default:
                        {
                            Console.WriteLine("Неверный ввод.");
                            Console.WriteLine("------------------------------------");
                            break;
                        }
                }
                if (num == 0) break;
            }

            //-----------------------------------------------------------------------------------------------
            //2.Использование параметризованной коллекции LinkedList
            //-----------------------------------------------------------------------------------------------
            LinkedList<Cars> l = new LinkedList<Cars>();
            LinkedListNode<Cars> W_volvo = l.AddLast(new Wagon(3.5, "Volvo_L", "S60", 58, true, true, 4.2, 4.2));
            LinkedListNode<Cars> C_audi = l.AddLast(new Cars(2.1, "Audi_L", "A8", 150));
            LinkedListNode<Cars> C_opel_1 = l.AddLast(new Cars(1.7, "Opel_L", "Vectra", 120));
            LinkedListNode<Cars> C_bmw = l.AddLast(new Cars(1.8, "BMW_L", "E39", 120));
            LinkedListNode<Cars> W_iveco = l.AddLast(new Wagon(7.3, "IVECO_L", "S-Way", 85, false, false, 0, 0));
            LinkedListNode<Cars> C_opel_2 = l.AddLast(new Cars(1.5, "Opel_L", "Astra", 100));
            LinkedListNode<Cars> W_scania = l.AddLast(new Wagon(12, "Scania_L", "R-Series", 72, true, false, 9, 3.5));
            menu();
        _b2:
            while (true)
            {
                Console.Write("Выберите пункт меню:  ");
                string str2 = Console.ReadLine();
                Console.WriteLine("------------------------------------");
                int num2;
                if (Int32.TryParse(str2, out num2) == false)
                {
                    Console.WriteLine("Неверный ввод.");
                    Console.WriteLine("------------------------------------");
                    goto _b2;
                }
                switch (num2)
                {
                    case 0: break;
                    case 1: { method1_LinkedList(l); break; }
                    case 2: { method2_LinkedList(l); break; }
                    case 3: { method3_LinkedList(l); break; }
                    case 4: { method4_LinkedList(l); break; }
                    case 5: { method5_LinkedList(l); break; }
                    case 6: { method6_LinkedList(l); break; }
                    case 7: { method7_LinkedList(l); break; }
                    case 8: { method8_LinkedList(ref l); break; }
                    case 9: { method9_LinkedList(ref l); break; }
                    case 10: { method10_LinkedList(l); break; }
                    case 11: { menu(); break; }
                    default:
                        {
                            Console.WriteLine("Неверный ввод.");
                            Console.WriteLine("------------------------------------");
                            break;
                        }
                }
                if (num2 == 0) break;
            }
            //-----------------------------------------------------------------------------------------------
            //3. Обобщенный метод
            //Создайте обобщенный метод, который получает массив произвольного типа 
            //и возвращает количество элементов, не равных null.
            //-----------------------------------------------------------------------------------------------
            int[] mas = new int[] { 4, 5, 5, 1, 5, 3 };
            string[] zzz = new string[] { null, "dsdf", "adqwerqr", null, "zvsdf" };
            Console.WriteLine($"Количество элементов в массиве (int) не равных null - {method<int>(mas)}");
            Console.WriteLine($"Количество элементов в массиве (string) не равных null - {method<string>(zzz)}");
        }
    }
}
