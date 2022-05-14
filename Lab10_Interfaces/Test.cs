using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Interfaces
{
    public class Test : Challenge                                   //производный класс от базового класса Challenge
    {
        string theme;                                               //поле производного класса

        public string Theme                                         //свойство
        {
            get
            {
                return theme;
            }
            set
            {
                theme = value;
            }
        }
        public Test() : base()                                      //конструктор по-умолчанию с вызовом конструктора базового класса
        {
            Theme = "NoName";
        }
        public Test(string a, int b) : base(b, "Test")                //конструктор с вызовом конструктора базового класса
        {
            Theme = a;
        }

        public override void Show()                                 //виртуальный метод
        {
            base.Show();                                            //вызов метода Show базового класса
            Console.WriteLine($"Theme: {Theme}");
        }
        public new void Show1()                                     //не виртуальный метод
        {
            base.Show1();
            Console.WriteLine($"Theme: {Theme}");
        }
        public override object Init()                               //виртуальный метод, реализующий интерфейс 
        {
            Challenge c = (Challenge)base.Init();
            string[] themes = { "Calculation of limits", "The structure of the brain", "Irregular Verbs", "Abstract classes" };
            Test t = new Test(themes[rnd.Next(themes.Length)], c.Grade);
            return t;
        }
        public override bool Equals(object obj)                     //переопределение метода Equals
        {
            if (obj is Test)
            {
                Test c = (Test)obj;
                return c.Name == this.Name && c.Grade == this.Grade && c.Theme == this.Theme;
            }
            return false;
        }

        public Challenge GetBase
        {
            get
            {
                return new Challenge(this.grade, this.theme);
            }
        }

        public Test GetTest
        {
            get 
            { 
                return new Test(this.theme, this.grade); 
            }
        }

        public override int GetHashCode()
        {
            return this.Grade;
        }
    }
}
