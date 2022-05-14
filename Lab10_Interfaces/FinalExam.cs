using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Interfaces
{
    public class FinalExam : Challenge                                      //производный класс от базового класса Challenge
    {
        string specialty;                                                   //поле производного класса
        public string Specialty                                             //свойство
        {
            get
            {
                return specialty;
            }
            set
            {
                specialty = value;
            }
        }
        public FinalExam() : base()                                         //конструктор по-умолчанию с вызовом конструктора базового класса
        {
            Specialty = "NoName";
        }
        public FinalExam(string b, int a) : base(a, "FinalExam")              //конструктор с вызовом конструктора базового класса
        {
            Specialty = b;
        }
        public override void Show()                                         //виртуальный метод
        {
            base.Show();                                                    //вызов метода Show базового класса
            Console.WriteLine($"Specialty: {Specialty}");
        }
        public new void Show1()                                             //не виртуальный метод
        {
            base.Show1();
            Console.WriteLine($"Specialty: {Specialty}");
        }
        public override object Init()                                       //виртуальный метод, реализующий интерфейс 
        {
            Challenge c = (Challenge)base.Init();
            string[] specialties = { "Software engineer", "Lawyer", "Mathematician", "Medical doctor" };
            FinalExam f = new FinalExam(specialties[rnd.Next(specialties.Length)], c.Grade);
            return f;
        }
        public override bool Equals(object obj)                             //переопределение метода Equals
        {
            if (obj is FinalExam)
            {
                FinalExam c = (FinalExam)obj;
                return c.Name == this.Name && c.Grade == this.Grade && c.Specialty == this.Specialty;
            }
            return false;
        }

        public Challenge GetBase
        {
            get
            {
                return new Challenge(this.grade, this.name);
            }
        }
    }
}
