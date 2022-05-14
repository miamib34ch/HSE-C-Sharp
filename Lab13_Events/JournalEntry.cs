using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab12_CollectionsCreatedByUser;

namespace Lab13_Events
{
    public class JournalEntry
    {
        public string NameCollection { get; set; }
        public string Change { get; set; }
        public MyCollection Data { get; set; }

        public JournalEntry(object source, CollectionHandlerEventArgs args)
        {
            NameCollection = ((MyNewCollection)source).NameCollection;
            Change = args.Change;
            Data = new MyCollection(args.Obj.data.Grade, args.Obj.data.Name);
        }

    }
}
