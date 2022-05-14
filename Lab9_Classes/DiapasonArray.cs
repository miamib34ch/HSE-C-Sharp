using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_Classes
{
    public class DiapasonArray
    {
        Diapason[] arr;
        static Random rnd = new Random();
        public Diapason[] Array
        {
            get
            {
                return arr;
            }
            set
            {
                arr = value;
            }
        }
        #region Конструкторы
        public DiapasonArray()                          //конструктор по умолчанию
        {
            Array = new Diapason[1];
        }
        public DiapasonArray(int size) 					//конструктор с параметром
        {
            Array = new Diapason[size];
            double maxLength = 0;
            int index_max = 0;
            for (int i = 0; i < size; i++)
            {
                Diapason obj = new Diapason();
                obj.X = rnd.Next(1, 100);
                obj.Y = rnd.Next(1, 100);
                obj.Z = rnd.Next(1, 100);
                obj.Belong = obj.Belong_F(obj.X, obj.Y, obj.Z);
                arr[i] = obj;
                if (!obj > maxLength)
                {
                    maxLength = !obj;
                    index_max = i;
                }
                obj.Print();
            }
            Console.WriteLine($"Индекс массива с масимальным значением длины диапазона ({maxLength}) равен {index_max}");
        }
        public DiapasonArray(int size, int a) 			//конструктор с двумя параметрами
        {
            Array = new Diapason[size];
            double maxLength = 0;
            int index_max = 0;
            for (int i = 0; i < size; i++)
            {
                Diapason obj = new Diapason(Program.Enter_Double("Введите начало диапазона: "), Program.Enter_Double("Введите конец диапазона: "), Program.Enter_Double("Введите число на проверку вхождения в диапазон: "));
                arr[i] = obj;
                if (!obj > maxLength)
                {
                    maxLength = !obj;
                    index_max = i;
                }
                obj.Print();
            }
            Console.WriteLine($"Индекс массива с масимальным значением длины диапазона ({maxLength}) равен {index_max}");
        }
        #endregion
        public Diapason this[int index]		//индексатор 
        {
            get
            {
                if (index < Array.Length)
                    return Array[index];
                else
                {
                    Console.WriteLine("Индекс вне массива!");
                    Console.WriteLine("Последний элемент массива: ");
                    return Array[Array.Length - 1];
                }
            }
            set
            {
                if (index < Array.Length)
                    Array[index] = value;
                else
                    Console.WriteLine("Индекс вне массива!");
            }
        }
    }
}
