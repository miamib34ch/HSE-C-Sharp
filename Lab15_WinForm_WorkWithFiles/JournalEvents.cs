using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab15_WinForm_WorkWithFiles
{
    public class JournalEvents
    {
        static JournalEntry[] arr = new JournalEntry[0];

        static public void CollectionChanged(object source, CollectionHandlerEventArgs args)
        {
            JournalEntry[] tmp = new JournalEntry[arr.Length + 1];
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                tmp[i] = arr[i];
            }
            tmp[tmp.Length - 1] = new JournalEntry(source, args);
            arr = new JournalEntry[tmp.Length];
            for (int i = 0; i <= arr.Length - 1; i++)
            {
                arr[i] = tmp[i];
            }
            File.WriteAllLines("JournalEvents.txt", (from str in arr select str.ToString()).ToArray());
        }

    }

}
