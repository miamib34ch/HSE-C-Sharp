using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Interfaces
{
    public class Student : IInit, ICloneable                                 //класс Student реализует интерфейс IInit
    {
        static Random rnd = new Random();                                   //поля
        public IdNumber id = new IdNumber(1);
        public string Name { get; set; }                                    //автоматическое свойство
        public Student()                                                    //конструктор по-умолчанию
        {
            Name = "NoName";
            id.number = 0;
        }
        public Student(string a, int d)                                     //конструктор с параметром 
        {
            Name = a;
            id.number = d;
        }
        public void Show()                                                  //метод, выводящий Name
        {
            Console.WriteLine($"Student: {Name}, ID: {id.number}");
        }
        public object Init()                                                //метод, реализующий интерфейс 
        {
            string[] themes = { "Ivanov", "Petrov", "Denisov", "Gubanov" };
            Student s = new Student(themes[rnd.Next(themes.Length)], rnd.Next(10000, 99999));
            return s;
        }
        public object Clone()                                               //реализация интерфейса IClonable
        {
            return new Student(this.Name, this.id.number);
        }
        public override bool Equals(object obj)                             //переопределение метода Equals
        {
            if (obj is Student)
            {
                Student s = (Student)obj;
                return s.Name == this.Name && s.id.number == this.id.number;
            }
            return false;
        }
        public object ShalowCopy()
        {
            return this.MemberwiseClone();                                  //поверхностное копирование 
        }
    }
}
