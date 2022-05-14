using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Interfaces
{
    public class Exam : Challenge                                       //производный класс от базового класса Challenge
    {
        string subject;                                                 //поле производного класса

        public string Subject                                           //свойство
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }
        public Exam() : base()                                          //конструктор по-умолчанию с вызовом конструктора базового класса
        {
            Subject = "NoName";
        }
        public Exam(string a, int b) : base(b, "Exam")                  //конструктор с вызовом конструктора базового класса
        {
            Subject = a;
        }

        public override void Show()                                     //виртуальный метод                   
        {
            base.Show();                                                //вызов метода Show базового класса
            Console.WriteLine($"Subject: {Subject}");
        }
        public new void Show1()                                         //не виртуальный метод   
        {
            base.Show1();
            Console.WriteLine($"Subject: {Subject}");
        }
        public override object Init()                                   //виртуальный метод, реализующий интерфейс 
        {
            Challenge c = (Challenge)base.Init();
            string[] subjects = { "Algebra", "Biology", "English", "Programming" };
            Exam e = new Exam(subjects[rnd.Next(subjects.Length)], c.Grade);
            return e;
        }
        public override bool Equals(object obj)                         //переопределение метода Equals
        {
            if (obj is Exam)
            {
                Exam e = (Exam)obj;
                return e.Name == this.Name && e.Grade == this.Grade && e.Subject == this.Subject;
            }
            return false;
        }
        public Challenge GetBase
        {
            get
            {
                return new Challenge(this.grade,this.name);
            }
        }
    }
}
