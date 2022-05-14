using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Interfaces
{
    public class Challenge : IInit, IComparable                          //класс Challenge реализует интерфейс IInit
    {
        protected int grade;                                             //поля, доступные только для классов иерархии
        protected string name;
        protected static Random rnd = new Random();

        public int Grade                                                 //свойство                
        {
            get
            {
                return grade;
            }
            set
            {
                if ((value >= 0) && (value <= 10)) grade = value;        //проверка значения оценки: не может быть меньше 0 и больше 10
                else
                {
                    Console.WriteLine("Error!");
                    grade = 0;
                }
            }
        }
        public string Name                                               //свойство
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Challenge()                                               //конструктор по-умолчанию
        {
            Grade = 0;
            Name = "NoName";
        }
        public Challenge(int a, string b)                                //конструктор с параметрами
        {
            Grade = a;
            Name = b;
        }
        public virtual void Show()                                       //виртуальный метод
        {
            Console.WriteLine($"{Name}: Grade - {Grade}");
        }
        public void Show1()                                              //не виртуальный метод, повторяющий метод Show()
        {
            Console.WriteLine($"{Name}: Grade - {Grade}");
        }
        public virtual object Init()                                     //виртуальный метод, реализующий интерфейс 
        {
            Challenge c = new Challenge(rnd.Next(0, 11), "NoName");
            return c;
        }
        public int CompareTo(object obj)                                //реализация интерфейса IComparable
        {
            return String.Compare(this.Name, ((Challenge)obj).Name);    //сравнение имён по алфавиту 
        }
        public override bool Equals(object obj)                         //переопределение метода Equals
        {
            if (obj is Challenge)
            {
                Challenge c = (Challenge)obj;
                return c.Name == this.Name && c.Grade == this.Grade;
            }
            return false;
        }
        public override string ToString()
        {
            return string.Format("{0}: Grade - {1}", (object)this.Name, (object)this.Grade);
        }
        public override int GetHashCode()
        {
            return this.Grade;
        }
    }
}
