using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_Classes
{
    public class Diapason
    {
        #region Поля
        double x;
        double y;
        double z;
        string belong;
        static int count;
        #endregion
        #region Свойства
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }
        public string Belong
        {
            get
            {
                return belong;
            }
            set
            {
                belong = value;
            }
        }
        #endregion
        #region Конструкторы
        public Diapason()                                                       //конструктор по умолчанию
        {
            X = 0;
            Y = 0;
            Z = 0;
            Belong = Belong_F(X, Y, Z);
            count++;
        }
        public Diapason(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            Belong = Belong_F(X, Y, Z);
            count++;
        }
        #endregion
        #region Методы
        public void Print()                                                     //функция вывода на экран 
        {
            Console.WriteLine("\nНачало диапазона: " + X);
            Console.WriteLine("Конец диапазона: " + Y);
            Console.WriteLine($"Принадлёжность {Z}: " + Belong);
            Console.WriteLine("Сколько объектов в программе: " + count);
            Console.WriteLine();
        }
        public string Belong_F(double x, double y, double z)                    //функция проверки принадлежности
        {
            string belong = "не принадлежит";
            if (((z >= y) && (z <= x)) || ((z <= y) && (z >= x)))
                belong = "принадлежит";
            return belong;
        }
        #endregion
        #region Унарные операции
        public static Diapason operator ++(Diapason obj)                           //перегруженная операция, инкремент
        {
            obj.X++;
            obj.Y++;
            obj.Belong = obj.Belong_F(obj.X, obj.Y, obj.Z);
            return obj;
        }
        public static double operator !(Diapason obj)                              //перегруженная операция, определяет длину диапазона
        {
            if (obj.X > obj.Y)
                return obj.X - obj.Y;
            else
                return obj.Y - obj.X;
        }
        #endregion
        #region Бинарные операции
        public static Diapason operator +(Diapason obj, int d)
        {
            obj.X += d;
            obj.Y += d;
            obj.Belong = obj.Belong_F(obj.X, obj.Y, obj.Z);
            return obj;
        }
        public static bool operator <(Diapason obj, int d)
        {
            if (((d >= obj.Y) && (d <= obj.X)) || ((d <= obj.Y) && (d >= obj.X)))
                return true;
            else
                return false;
        }
        public static bool operator >(Diapason obj, int d)
        {
            if (((d >= obj.Y) && (d <= obj.X)) || ((d <= obj.Y) && (d >= obj.X)))
                return false;
            else
                return true;
        }
        #endregion
        #region Операции приведения типа
        public static implicit operator double(Diapason obj)
        {
            return obj.Y;
        }
        public static explicit operator int(Diapason obj)
        {

            return (int)(Math.Truncate(obj.X));
        }
        #endregion
        public override bool Equals(object obj)
        {
            if (obj is Diapason)
            {
                Diapason m = (Diapason)obj;
                return this.X == m.X && this.Y == m.Y;
            }
            else return false;
        }
    }
}
