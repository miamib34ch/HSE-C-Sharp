using Lab10_Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_CollectionsCreatedByUser
{
    public class MyCollection : IEnumerable
    {
        //стэк на основе однонаправленного списка

        public Challenge data;  //Информационное поле
        public MyCollection next;      //Адресное поле
        public int Count { get; set; }

        public MyCollection()
        {
            data = null;
            next = null;
            Count = 0;
        }

        public MyCollection(int capacity)
        {
            MyCollection tmp = MakeStack(capacity);
            data = tmp.data;
            next = tmp.next;
            Count = capacity;
        }

        public MyCollection(int i, string s)
        {
            data = new Challenge(i, s);
            next = null;
        }

        public MyCollection(MyCollection c)
        {
            data = c.data;
            next = c.next;
            Count = c.Count;
        }

        static MyCollection MakePoint(int i, string s)
        {
            MyCollection p = new MyCollection(i, s);
            return p;
        }

        public static MyCollection MakeStack(int size)
        {
            Random rnd = new Random();
            string[] subject = { "biology", "algebra", "geometry", "project", "chemistry", "math", "english", "russian", "programming", "physics", "history" };
            MyCollection beg = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
            MyCollection r = beg;
            for (int i = 1; i < size; i++)
            {
                MyCollection p = MakePoint(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
                r.next = p;
                r = p;
            }
            return beg;
        }

        public static void ShowList(MyCollection beg)
        {
            if (beg == null)
            {
                Console.WriteLine("The List is empty");
                return;
            }
            MyCollection p = beg;
            while (p != null)
            {
                p.data.Show();
                p = p.next;//переход к следующему элементу
            }
            Console.WriteLine($"\nРазмер коллекции: {beg.Count}");
        }

        public static MyCollection Add(MyCollection c)
        {
            Random rnd = new Random();
            string[] subject = { "biology", "algebra", "geometry", "project", "chemistry", "math", "english", "russian", "programming", "physics", "history" };
            if (c == null)
            {
                c = new MyCollection(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
                c.Count = c.Count + 1;
                return c;
            }
            else
            {
                MyCollection tmp = new MyCollection(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
                tmp.next = c;
                tmp.Count = c.Count + 1;
                return tmp;
            }
        }

        public static MyCollection DeletePoint(MyCollection beg)
        {
            if (beg == null)
            {
                return beg;
            }
            if (beg.next == null)
            {
                beg.Count = beg.Count - 1;
                return beg.next;
            }
            beg.next.Count = beg.Count - 1;
            return beg.next;
        }

        public static void Search(MyCollection beg, int gr_sh)
        {
            MyCollection p = beg;
            while (p.data.Grade != gr_sh)
            {
                p = p.next;
            }
            p.data.Show();
        }

        public MyCollection Copy()
        {
            return this;
        }

        public static MyCollection Clone(MyCollection toclone)
        {
            MyCollection r = toclone;
            while (r.next != null)
            {
                r = r.next;
            }
            MyCollection clone = new MyCollection(r.data.Grade, r.data.Name);
            clone.Count = 1;
            r = toclone;
            for (int i = 0; i < toclone.Count - 1; i++)
            {
                while (!(r.next.data.Grade == clone.data.Grade && r.next.data.Name == clone.data.Name))
                {
                    r = r.next;
                }
                MyCollection tmp = new MyCollection(r.data.Grade, r.data.Name);
                tmp.next = clone;
                clone = tmp;
                r = toclone;
            }
            clone.Count = toclone.Count;
            return clone;
        }

        public static void Clear(ref MyCollection c)
        {
            c = null;
            GC.Collect();
        }

        public virtual MyCollection this[int index]
        {
            get
            {
                MyCollection myCollection = this;
                if (index > this.Count - 1)
                    return this;
                for (int index1 = 0; index1 < index; ++index1)
                    myCollection = myCollection.next;
                return myCollection;
            }
            set
            {
                MyCollection myCollection = this;
                if (index > this.Count - 1)
                    return;
                for (int index1 = 0; index1 < index; ++index1)
                    myCollection = myCollection.next;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new MyNumerator(this);
        }

    }

    class MyNumerator : IEnumerator
    {

        MyCollection beg;
        MyCollection current;

        public MyNumerator(MyCollection collection)
        {
            beg = collection;
            current = null;
        }

        object IEnumerator.Current
        {
            get
            {
                return current;
            }
        }

        bool IEnumerator.MoveNext()
        {
            if (current == null)
            {
                current = beg;
            }
            else
            {
                current = current.next;
            }
            return current != null;
        }

        void IEnumerator.Reset()
        {
            current = this.beg;
        }

    }
}
