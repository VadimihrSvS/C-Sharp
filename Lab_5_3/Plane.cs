using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab6
{
    [Serializable]
    sealed class Plane : Aircraft
    {
        double wingspan, chord; //размах и хорда (ширина) крыла

        public Plane(double g, double m, double wingspan, double chord ) : base(g, m)
        {
            Wingspan = wingspan;
            Chord = chord;
        }

        public double Wingspan
        { 
            get => wingspan;
            set
            {
                if (value >= 0)
                    wingspan = value;
                else
                    wingspan = 0;
            }
             
        }
        public double Chord
        {
            get => chord;
            set
            {
                if (value >= 0)
                    chord = value;
                else
                    chord = 0;
            }
        }

        public override double Keff()
        {
            return M / G;
        }

        public override double UdelNagr(int k)
        {
            return k*(M + G)/ (Wingspan*Chord);// удельная нагрузка равна отношению снаряженной массы к площади крыла
        }
      

        public override void Print()
        {
            Console.WriteLine($"Самолет массой {G}, полезная нагрузка {M}, размах крыла {Wingspan}, хорда крыла {Chord}");
        }
        public static void SaveClass(string filename)   // рефлексия
        {
            Type t = typeof(Plane);
            StreamWriter f = new StreamWriter(filename);
            f.WriteLine("Полное имя класса:" + t.FullName);
            if (t.IsAbstract) f.WriteLine("Абстрактный класс");
            if (t.IsClass) f.WriteLine("Обычный класс");
            if (t.IsInterface) f.WriteLine("Интерфейс");
            if (t.IsEnum) f.WriteLine("Перечисление");
            if (t.IsSealed) f.WriteLine("Закрыт для наследования");
            f.WriteLine("Базовый класс-" + t.BaseType);

            FieldInfo[] fields = t.GetFields();
            if (fields.Count() > 0)
                f.WriteLine("*** Поля класса ***");
            foreach (var field in fields)
            {
                f.WriteLine(field);
            }

            PropertyInfo[] propertyies = t.GetProperties();
            if (propertyies.Count() > 0)
                f.WriteLine("*** Свойства класса ***");
            foreach (var property in propertyies)
            {
                f.WriteLine(property);
            }

            MethodInfo[] methods = t.GetMethods();
            if (methods.Count() > 0)
                f.WriteLine("*** Методы класса ***");
            foreach (var method in methods)
            {
                f.WriteLine(method);
            }
            f.Close();
        }
        public void SaveObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(G);
            bw.Write(M);
            bw.Write(wingspan);
            bw.Write(chord);        
            fs.Close();  
        }
        public static Plane LoadObject(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            double x = br.ReadDouble();
            double y = br.ReadDouble();
            double z = br.ReadDouble();
            double q = br.ReadDouble();
            fs.Close();
            return new Plane(x, y, z, q);
        }

        public void Serialize(string filename)       //сериализация
        {
            Stream fs = new FileStream(filename, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, this);
            fs.Close();
        }
        public static Plane Deserialize(string filename)
        {
            Stream fs = new FileStream(filename, FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();
            Plane plane = (Plane)formatter.Deserialize(fs);
            fs.Close();
            return plane;
        }
    }
}
