using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10_Interfaces
{
    public class SortByGrade : IComparer                           //класс реализующий интерфейс IComparer
    {
        public int Compare(object x, object y)
        {
            Challenge c1 = (Challenge)x;
            Challenge c2 = (Challenge)y;
            if (c1.Grade < c2.Grade) return -1;
            else if (c1.Grade == c2.Grade) return 0;
            else return 1;
        }
    }
}
