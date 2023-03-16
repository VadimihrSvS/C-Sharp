using System;
using System.IO;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Temp");
            while (true)
            {
                Console.WriteLine("*********************************************");
                Console.WriteLine("*                Главное меню               *");
                Console.WriteLine("*********************************************");
                Console.WriteLine("1 - установить текущий диск/каталог");
                Console.WriteLine("2 - вывод списка всех каталогов в текущем");
                Console.WriteLine("3 - вывод списка всех файлов в текущем каталоге");
                Console.WriteLine("4 - вывод на экран содержимого указанного файла");
                Console.WriteLine("5 - создание каталога в текущем");
                Console.WriteLine("6 - удаления каталога по номеру, если он пустой");
                Console.WriteLine("7 - удаление файлов с указанными номерами");
                Console.WriteLine("8 - вывод списка всех файлов с указанной датой создания в текущем каталоге и подкаталогах");
                Console.WriteLine("9 - вывод списка всех текстовых файлов в текущем каталоге и подкаталогах, в которых есть заданный текст");
                Console.WriteLine("0 - выход");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            f1(ref dir);
                            break;
                        case 2:
                            f2(dir);
                            break;
                        case 3:
                            f3(dir);
                            break;
                        case 4:
                            f4(dir);
                            break;
                        case 5:
                            f5(dir);
                            break;
                        case 6:
                            f6(dir);
                            break;
                        case 7:
                            f7(dir);
                            break;
                        case 8:
                            f8(dir);
                            break;
                        case 9:
                            f9(dir);
                            break;
                        case 0:
                            return;
                    }
                }
                catch
                {
                    Console.WriteLine("Неверный выбор пункта меню");
                    Console.ReadKey();
                }
            }
        }

        static void f1(ref DirectoryInfo d)//установить текущий диск/каталог  
        {
            Console.WriteLine($"Текущий каталог {d.FullName}");
            Console.WriteLine("Введите имя диска/каталога:");
            string str = Console.ReadLine();
            DirectoryInfo directoryInfo = new DirectoryInfo($"{str}");
            if (directoryInfo.Exists)
            {
                d = directoryInfo;
            }
            else
            {
                Console.WriteLine("Данного диска/каталога не существует.");
            }
            Console.WriteLine($"Текущий каталог {d.FullName}");
            Console.ReadKey();

        }
        static void f2(DirectoryInfo d)//вывод списка всех каталогов в текущем
        {
            DirectoryInfo[] directories = d.GetDirectories();
            int n = 0;
            foreach(DirectoryInfo directory in directories)
            {
                Console.WriteLine($"{++n})  {directory.Name}  {directory.CreationTime}");
            }
            Console.ReadKey();
        }
        static void f3(DirectoryInfo d)//вывод списка всех файлов в текущем каталоге
        {
            FileInfo[] files = d.GetFiles();
            int n = 0;
            foreach (FileInfo file in files)
            {
                Console.WriteLine($"{++n})  {file.Name}  {file.CreationTime}");
            }
            Console.ReadKey();
        }
        static void f4(DirectoryInfo d)//вывод на экран содержимого указанного файла
        {
            f3(d);
            Console.WriteLine("Введите номер файла");
            int index = Convert.ToInt32(Console.ReadLine());
            FileInfo[] files = d.GetFiles();
            if (index < 1 || index > files.Length)
            {
                Console.WriteLine("Неверный индекс");
                return;
            }
            if (files[index - 1].Extension != ".txt")
            {
                Console.WriteLine("Это не текстовый файл");
                return;
            }
            StreamReader reader = new StreamReader(files[index - 1].FullName);
            string str = reader.ReadToEnd();
            Console.WriteLine(str);
            reader.Close();
            Console.ReadKey();
        }
        static void f5(DirectoryInfo d) //создание каталога в текущем
        {
            Console.WriteLine("Введите имя каталога:");
            string str = Console.ReadLine();
            DirectoryInfo directoryInfo = new DirectoryInfo($"{d.FullName}\\{str}");
            if (directoryInfo.Exists)
            {
                Console.WriteLine("такой каталог уже существует");
                return;
            }
            d.CreateSubdirectory(str);
            Console.WriteLine("каталог создан");
            Console.ReadKey();
        }
        static void f6(DirectoryInfo d)//удаления каталога по номеру, если он пустой
        {
            f2(d);
            Console.WriteLine("Введите номер каталога");
            int index = Convert.ToInt32(Console.ReadLine());
            DirectoryInfo[] directories = d.GetDirectories();
            if (index <1||index > directories.Length)
            {
                Console.WriteLine("Неверный индекс");
                return;
            }
            directories[index - 1].Delete();
            Console.WriteLine("Каталог удален");
            Console.ReadKey();
        }
        static void f7(DirectoryInfo d) //удаление файлов с указанными номерами
        {
            f3(d);
            Console.WriteLine("Введите номер файла");
            int index = Convert.ToInt32(Console.ReadLine());
            FileInfo[] files = d.GetFiles();
            if (index < 1 || index > files.Length)
            {
                Console.WriteLine("Неверный индекс");
                return;
            }
            files[index - 1].Delete();
            Console.WriteLine("Файл удален");
            f3(d);
            Console.ReadKey();
        }
        static void f8(DirectoryInfo d)//вывод списка всех файлов с указанной датой создания
        {
            Console.WriteLine("Введите дату создания файла в формате ДД.ММ.ГГГГ");
            string date = Convert.ToString(Console.ReadLine()).Substring(0, 10);
            FileInfo[] files = d.GetFiles("*.*",SearchOption.AllDirectories);
            int n = 0;
            foreach (FileInfo file in files)
            {   
                if(Convert.ToString(file.CreationTime).Substring(0, 10) == date)
                {
                    Console.WriteLine($"{++n})  {file.Name}  {file.CreationTime}");
                }
            }
            if (n == 0)
            {
                Console.WriteLine("Файлов с данной датой создания не обнаружено");
            }
            Console.ReadKey();
        }
        
        static void f9(DirectoryInfo d)//вывод списка всех текстовых файлов, в которых заданный текст
        {
            Console.WriteLine("Введите текст для поиска");
            string text = Console.ReadLine();
            FileInfo[] textfiles = d.GetFiles("*.txt", SearchOption.AllDirectories);
            int n = 0;
            foreach (FileInfo file in textfiles)
            {
                using (StreamReader f = new StreamReader(file.FullName))
                {
                    if (f.ReadToEnd().Contains(text))
                    {
                        Console.WriteLine($"{++n})  {file.Name}  {file.CreationTime}");
                    }
                }
            }
            if (n == 0)
            {
                Console.WriteLine("Файлов с данным текстом не обнаружено");
            }
            Console.ReadKey();
        }    
    }
}
