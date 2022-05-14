using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab13_Events
{
    public class Journal
    {
        JournalEntry[] arr;
        string NameJournal;

        public Journal(string a)
        {
            arr = new JournalEntry[0];
            NameJournal = a;
        }

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
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
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
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
        }

        public void Show()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Журнал {NameJournal}, элемент: {i + 1}. Коллекция: {arr[i].NameCollection}; действие: {arr[i].Change}; Name: {arr[i].Data.data.Name}, Grade: {arr[i].Data.data.Grade}");
            }
        }

        public JournalEntry this[int index]		//индексатор 
        {
            get
            {
                if (index < arr.Length)
                    return arr[index];
                else
                {
                    Console.WriteLine("Индекс вне массива!");
                    Console.WriteLine("Последний элемент массива: ");
                    return arr[arr.Length - 1];
                }
            }
            set
            {
                if (index < arr.Length)
                    arr[index] = value;
                else
                    Console.WriteLine("Индекс вне массива!");
            }
        }

    }

}
