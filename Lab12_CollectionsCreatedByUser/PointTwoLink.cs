using Lab10_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_CollectionsCreatedByUser
{
    class PointTwoLink
    {
        public Challenge data;          //Информационное поле
        public PointTwoLink next, pred;              //Адресное поле следующего объекта и предыдущего 

        public PointTwoLink()
        {
            data = new Challenge();
            next = null;
            pred = null;
        }

        public PointTwoLink(int i, string s)
        {
            data = new Challenge(i, s);
            next = null;
            pred = null;
        }

        static PointTwoLink MakePoint(int i, string s)
        {
            PointTwoLink p = new PointTwoLink(i, s);
            return p;
        }

        public static PointTwoLink MakeList(int size)
        {
            Random rnd = new Random();
            string[] subject = { "biology", "algebra", "geometry", "project", "chemistry", "math", "english", "russian", "programming", "physics", "history" };
            PointTwoLink beg = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
            for (int i = 1; i < size; i++)
            {
                PointTwoLink p = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
                p.next = beg;
                beg.pred = p;
                beg = p;
            }
            return beg;
        }

        public static PointTwoLink MakeListToEnd(int size)
        {
            Random rnd = new Random();
            string[] subject = { "biology", "algebra", "geometry", "project", "chemistry", "math", "english", "russian", "programming", "physics", "history" };
            PointTwoLink beg = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
            PointTwoLink r = beg;
            for (int i = 1; i < size; i++)
            {
                PointTwoLink p = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
                r.next = p;
                p.pred = r;
                r = p;
            }
            return beg;
        }

        public static void ShowList(PointTwoLink beg)
        {
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            PointTwoLink p = beg;
            while (p != null)
            {
                p.data.Show();
                p = p.next;//переход к следующему элементу
            }
        }

        public static PointTwoLink DeletePoint(PointTwoLink beg, int gr_sh, string sub_sh)
        {
            PointTwoLink p = beg;
            if (beg.data.Name == sub_sh && beg.data.Grade == gr_sh)
            {
                beg = beg.next;
                beg.pred = null;
                return beg;
            }
            while (!(p.data.Name == sub_sh && p.data.Grade == gr_sh))
            {
                p = p.next;
            }
            p.pred.next = p.next;
            return beg;
        }
    }
}
