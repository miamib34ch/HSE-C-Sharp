using Lab10_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_CollectionsCreatedByUser
{
    class Point
    {
        public Challenge data;  //Информационное поле
        public Point next;      //Адресное поле

        public Point()
        {
            data = new Challenge();
            next = null;
        }

        public Point(int i, string s)
        {
            data = new Challenge(i, s);
            next = null;
        }

        static Point MakePoint(int i, string s)
        {
            Point p = new Point(i, s);
            return p;
        }

        public static Point MakeList(int size)
        {
            Random rnd = new Random();
            string[] subject = { "biology", "algebra", "geometry", "project", "chemistry", "math", "english", "russian", "programming", "physics", "history" };
            Point beg = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
            for (int i = 1; i < size; i++)
            {
                Point p = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
                p.next = beg;
                beg = p;
            }
            return beg;
        }

        public static Point MakeListToEnd(int size)
        {
            Random rnd = new Random();
            string[] subject = { "biology", "algebra", "geometry", "project", "chemistry", "math", "english", "russian", "programming", "physics", "history" };
            Point beg = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
            Point r = beg;
            for (int i = 1; i < size; i++)
            {
                Point p = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
                r.next = p;
                r = p;
            }
            return beg;
        }

        public static void ShowList(Point beg)
        {
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            Point p = beg;
            while (p != null)
            {
                p.data.Show();
                p = p.next;//переход к следующему элементу
            }
        }

        public static Point AddPoint(Point beg, int gr_sh, string sub_sh)
        {
            Console.Write("Введите оценку нового предмета: ");
            int grade = int.Parse(Console.ReadLine());
            Console.Write("Введите новый предмет: ");
            string sub = Console.ReadLine();
            Point NewPoint = MakePoint(grade, sub);
            if (beg == null)
            {
                beg = NewPoint;
                return beg;
            }
            Point p = beg;
            while (!(p.data.Name == sub_sh && p.data.Grade == gr_sh))
            {
                p = p.next;
            }
            NewPoint.next = p.next;
            p.next = NewPoint;
            return beg;
        }

    }
}
