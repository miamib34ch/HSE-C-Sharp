using Lab12_CollectionsCreatedByUser;

MyCollection c1 = new MyCollection();
c1 = MyCollection.MakeStack(20);
MyCollection c2 = new MyCollection();
c2 = MyCollection.MakeStack(20);
Console.WriteLine("Все элементы первой коллекции:");
MyCollection.ShowList(c1);
Choice_LINQ(c1);
Choice_Ext(c1);
Console.WriteLine();
Count_LINQ(c1);
Count_Ext(c1);
Console.WriteLine();
Console.WriteLine("Все элементы второй коллекции:");
MyCollection.ShowList(c2);
Console.WriteLine("Все испытания по биологии из двух коллекций (LINQ): ");
AllBio_LINQ(c1, c2);
Console.WriteLine("Все испытания по биологии из двух коллекций (Метод расширения): ");
AllBio_Ext(c1, c2);
Console.WriteLine();
Average_LINQ(c1);
Average_Ext(c1);
Console.WriteLine();
Console.WriteLine("Первая коллекция, сгруппированная по оценкам (LINQ): ");
Group_LINQ(c1);
Console.WriteLine("Первая коллекция, сгруппированная по оценкам (Метод расширения): ");
Group_Ext(c1);

#region Методы LINQ запросов
static void Choice_LINQ(MyCollection coll)
{
    string[] subjectsNames = (from MyCollection ch in coll where ch.data.Grade == 10 select ch.data.Name).ToArray();
    if (subjectsNames.Length > 0)
    {
        Console.WriteLine("Есть испытания с оценкой 10 по следующим предметам (LINQ):");
        foreach (string x in subjectsNames) Console.WriteLine(x);
    }
    else
    {
        Console.WriteLine("Испытаний с оценкой 10 нет ни по одному предмету (LINQ)");
    }
}

static void Count_LINQ(MyCollection coll)
{
    int count = (from MyCollection ch in coll where ch.data.Grade == 0 select ch).Count();
    Console.WriteLine($"Количество испытаний с оценкой 0 (LINQ): {count}");
}

static void AllBio_LINQ(MyCollection coll, MyCollection coll2)
{
    var un = (from MyCollection ch in coll where ch.data.Name == "biology" select ch).Union(from MyCollection ch in coll2 where ch.data.Name == "biology" select ch);
    foreach (MyCollection x in un) x.data.Show();
}

static void Average_LINQ(MyCollection coll)
{
    var average = (from MyCollection ch in coll select ch.data.Grade).Average();
    Console.WriteLine($"Средняя оценка всех оценок первой коллекции (LINQ): {average}");
}

static void Group_LINQ(MyCollection coll)
{
    var group = from MyCollection ch in coll group ch by ch.data.Grade;
    foreach (IGrouping<int, MyCollection> g in group)
    {
        Console.WriteLine("Ключ: " + g.Key);
        foreach (var t in g)
            t.data.Show();
        Console.WriteLine();
    }
}
#endregion

#region Расширенные методы
static void Choice_Ext(MyCollection coll)
{
    MyCollection[] ch = new MyCollection[0];
    foreach (MyCollection x in coll)
    {
        MyCollection[] tmp = new MyCollection[ch.Length + 1];
        for (int i = 0; i < ch.Length; i++)
            tmp[i] = ch[i];
        ch = new MyCollection[tmp.Length];
        for (int i = 0; i < ch.Length; i++)
            ch[i] = tmp[i];
        ch[ch.Length - 1] = x;
    }
    var subjectsNames = ch.Where(ch => ch.data.Grade == 10);
    if (subjectsNames.Count() > 0)
    {
        Console.WriteLine("Есть испытания с оценкой 10 по следующим предметам (Метод расширения):");
        foreach (MyCollection x in subjectsNames) Console.WriteLine(x.data.Name);
    }
    else
    {
        Console.WriteLine("Испытаний с оценкой 10 нет ни по одному предмету (Метод расширения)");
    }
}

static void Count_Ext(MyCollection coll)
{
    MyCollection[] ch = new MyCollection[0];
    foreach (MyCollection x in coll)
    {
        MyCollection[] tmp = new MyCollection[ch.Length + 1];
        for (int i = 0; i < ch.Length; i++)
            tmp[i] = ch[i];
        ch = new MyCollection[tmp.Length];
        for (int i = 0; i < ch.Length; i++)
            ch[i] = tmp[i];
        ch[ch.Length - 1] = x;
    }
    var count = ch.Where(ch => ch.data.Grade == 0);
    Console.WriteLine($"Количество испытаний с оценкой 0 (Метод расширения): {count.Count()}");
}

static void AllBio_Ext(MyCollection coll, MyCollection coll2)
{
    MyCollection[] ch = new MyCollection[0];
    foreach (MyCollection x in coll)
    {
        MyCollection[] tmp = new MyCollection[ch.Length + 1];
        for (int i = 0; i < ch.Length; i++)
            tmp[i] = ch[i];
        ch = new MyCollection[tmp.Length];
        for (int i = 0; i < ch.Length; i++)
            ch[i] = tmp[i];
        ch[ch.Length - 1] = x;
    }
    var subjectsNames = ch.Where(ch => ch.data.Name == "biology");

    MyCollection[] ch2 = new MyCollection[0];
    foreach (MyCollection x in coll2)
    {
        MyCollection[] tmp = new MyCollection[ch2.Length + 1];
        for (int i = 0; i < ch2.Length; i++)
            tmp[i] = ch2[i];
        ch2 = new MyCollection[tmp.Length];
        for (int i = 0; i < ch2.Length; i++)
            ch2[i] = tmp[i];
        ch2[ch2.Length - 1] = x;
    }
    var subjectsNames2 = ch2.Where(ch2 => ch2.data.Name == "biology");

    foreach (MyCollection x in subjectsNames) x.data.Show();
    foreach (MyCollection x in subjectsNames2) x.data.Show();

}

static void Average_Ext(MyCollection coll)
{
    MyCollection[] ch = new MyCollection[0];
    foreach (MyCollection x in coll)
    {
        MyCollection[] tmp = new MyCollection[ch.Length + 1];
        for (int i = 0; i < ch.Length; i++)
            tmp[i] = ch[i];
        ch = new MyCollection[tmp.Length];
        for (int i = 0; i < ch.Length; i++)
            ch[i] = tmp[i];
        ch[ch.Length - 1] = x;
    }
    var average = ch.Average(ch => ch.data.Grade);
    Console.WriteLine($"Средняя оценка всех оценок первой коллекции (Метод расширения): {average}");
}

static void Group_Ext(MyCollection coll)
{
    MyCollection[] ch = new MyCollection[0];
    foreach (MyCollection x in coll)
    {
        MyCollection[] tmp = new MyCollection[ch.Length + 1];
        for (int i = 0; i < ch.Length; i++)
            tmp[i] = ch[i];
        ch = new MyCollection[tmp.Length];
        for (int i = 0; i < ch.Length; i++)
            ch[i] = tmp[i];
        ch[ch.Length - 1] = x;
    }
    var group = ch.GroupBy(ch => ch.data.Grade);

    foreach (IGrouping<int, MyCollection> g in group)
    {
        Console.WriteLine("Ключ: " + g.Key);
        foreach (var t in g)
            t.data.Show();
        Console.WriteLine();
    }
}
#endregion
