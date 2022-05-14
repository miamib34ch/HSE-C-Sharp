using Lab10_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12_CollectionsCreatedByUser
{
    class BinaryTree
    {
        public Challenge data;          //Информационное поле
        public BinaryTree left, right;              //Адресное поле левого и правого поддерева 
        int Count = 0;

        public BinaryTree()
        {
            data = new Challenge();
            left = null;
            right = null;
        }

        public BinaryTree(int i, string s)
        {
            data = new Challenge(i, s);
            left = null;
            right = null;
        }

        public int Run(BinaryTree p)
        {
            if (p != null)
            {
                this.Count++;
                Run(p.left);
            }
            return this.Count;
        }

        public static void ShowTree(BinaryTree p, int l)
        {
            if (p != null)
            {
                ShowTree(p.left, l + 3);//переход к левому поддереву
                                        //формирование отступа
                for (int i = 0; i < l; i++) Console.Write(" ");
                Console.WriteLine(p.data);//печать узла
                ShowTree(p.right, l + 3);//переход к правому поддереву
            }
        }

        public static BinaryTree First()
        {
            BinaryTree p = new BinaryTree(5, "root");
            return p;
        }

        public static BinaryTree Add(BinaryTree root, int gr, string s)
        {
            BinaryTree p = root;
            BinaryTree r = null;
            bool ok = false;
            while (p != null && !ok)
            {
                r = p;
                if ((gr == p.data.Grade) && (s == p.data.Name)) ok = true;
                else
                    if (gr < p.data.Grade) p = p.left;
                else p = p.right;
            }
            if (ok) return p;
            BinaryTree NewPoint = new BinaryTree(gr, s);
            if (gr < r.data.Grade) r.left = NewPoint;
            else r.right = NewPoint;
            return NewPoint;
        }

        public static BinaryTree IdealTree(int size, BinaryTree p)
        {
            Random rnd = new Random();
            string[] subject = { "biology", "algebra", "geometry", "project", "chemistry", "math", "english", "russian", "programming", "physics", "history" };
            BinaryTree r;
            int nl, nr;
            if (size == 0) { p = null; return p; }
            nl = size / 2;
            nr = size - nl - 1;
            r = new BinaryTree(rnd.Next(0, 11), subject[rnd.Next(0, 11)]);
            r.left = IdealTree(nl, r.left);
            r.right = IdealTree(nr, r.right);
            return r;
        }

        public static void Transform(BinaryTree root, BinaryTree idtree)
        {
            if (idtree != null)
            {
                Add(root, idtree.data.Grade, idtree.data.Name);
                Transform(root, idtree.left);
                Transform(root, idtree.right);
            }
        }

    }
}
