using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15_WinForm_WorkWithFiles
{
    public class JournalEntry
    {
        public string Change { get; set; }
        public string Arr { get; set; }

        public JournalEntry(object source, CollectionHandlerEventArgs args)
        {
            Change = args.Change;
            Arr = args.ArrStr;
        }

        public override string ToString()
        {
            return $"Действие: {Change}, строка: {Arr}";
        }
    }

}
