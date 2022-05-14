using Lab10_Interfaces;
using Lab12_CollectionsCreatedByUser;

namespace Lab13_Events
{
    class Program
    {
        static void Main(string[] args)
        {

            MyNewCollection c1 = new MyNewCollection("Первая коллекция");
            c1.NameCollection = "Первая коллекция";
            MyNewCollection c2 = new MyNewCollection("Вторая коллекция");
            c2.NameCollection = "Вторая коллекция";

            Journal first = new Journal("первый");
            Journal second = new Journal("второй");

            c1.CollectionCountChanged += first.CollectionCountChanged;
            c1.CollectionReferenceChanged += first.CollectionReferenceChanged;
            c1.CollectionReferenceChanged += second.CollectionReferenceChanged;
            c2.CollectionReferenceChanged += second.CollectionReferenceChanged;

            c1.Add(new Challenge(10, "TestSubject"));
            c1.Add(new Challenge(9, "2TestSubject"));
            c1.Add(new Challenge(8, "3TestSubject"));
            c1.AddDefault();
            c1.AddDefault();
            c1.AddDefault();

            c2.Add(new Challenge(1, "TestSubject22"));
            c2.Add(new Challenge(2, "2TestSubject22"));
            c2.Add(new Challenge(3, "3TestSubject22"));

            c1.Remove(1); //в скобке индекс начиная с 0
            c2.Remove(1);

            c1[0] = new MyCollection(0, "Changed");
            c2[1] = new MyCollection(2, "Changed2");

            first.Show();
            second.Show();
            Console.ReadLine();
        }
    }
}