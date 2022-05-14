using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab12_CollectionsCreatedByUser;

namespace Lab13_Events
{
    public class CollectionHandlerEventArgs : System.EventArgs
    {
        public string Change
        {
            get;
            set;
        }
        public MyCollection Obj
        {
            get;
            set;
        }

        public CollectionHandlerEventArgs(string u, MyCollection s)
        {
            Obj = new MyCollection(s.data.Grade, s.data.Name);
            Change = u;
        }
    }

}
