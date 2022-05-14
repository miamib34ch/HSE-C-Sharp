using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15_WinForm_WorkWithFiles
{
    public class CollectionHandlerEventArgs : System.EventArgs
    {
        public string Change
        {
            get;
            set;
        }

        public string ArrStr
        {
            get;
            set;
        }

        public CollectionHandlerEventArgs(string u, string ArrStr)
        {
            Change = u;
            this.ArrStr = ArrStr;
        }
    }

}
