using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab10_Interfaces;

namespace Lab11_Collections
{
    class TestCollections
    {
        Stack<Challenge> st1;               //Стэк, последним пришёл, первым вышел, доступен только первый
        Stack<string> st2;
        Dictionary<Challenge, Test> dic1;   //Словарь - ассоциативный массив, универсальный тип в отличие от hashtable
        Dictionary<string, Test> dic2;
        Stopwatch sw = new Stopwatch();     //считает сколько времени выполняется
        Challenge first;
        Test firstV;
        Challenge middle;
        Test middleV;
        Challenge end;
        Test endV;
        Challenge outof = new Challenge();
        Test outofV = new Test();

        public TestCollections()
        {
            st1 = new Stack<Challenge>(1000);   //в () указан размер
            st2 = new Stack<string>(1000);
            dic1 = new Dictionary<Challenge, Test>(1000);
            dic2 = new Dictionary<string, Test>(1000);
            for (int i = 0; i < 1000; i++)
            {
                Test t = (Test)(new Test()).Init();
                st1.Push(t.GetBase);            //вставить в стэк
                st2.Push(t.GetBase.ToString());
                try
                {
                    dic1.Add(t.GetBase, t);
                    dic2.Add(t.GetBase.ToString(), t);
                }
                catch
                {

                }
                if (i == 0)
                {
                    first = t.GetBase;
                    firstV = t.GetTest;
                }
                if (i == 500)
                {
                    middle = t.GetBase;
                    middleV = t.GetTest;
                }
                if (i == 999)
                {
                    end = t.GetBase;
                    endV = t.GetTest;
                }
            }
            Menu();
        }
        private void Menu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие:" +
                    "\n1.Добавить элемент в коллекцию" +
                    "\n2.Удалить элемент из коллекции" +
                    "\n3.Посмотреть все ключи" +
                    "\n4.Посмотреть затраченное время на поиск" +
                    "\n5.Выход");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Введите тему теста: ");
                        string th = Console.ReadLine();
                        Console.Write("Введите оценку: ");
                        int gr = int.Parse(Console.ReadLine());
                        Test tt = new Test(th, gr);
                        Challenge bb = tt.GetBase;
                        string aa = bb.ToString();
                        st1.Push(bb);
                        st2.Push(aa);
                        try
                        {
                            dic1.Add(bb, tt);       //добавить в словарь
                            dic2.Add(aa, tt);
                        }
                        catch
                        {
                            Console.WriteLine("Такой элемент уже находится в коллекции!");
                        }
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Введите тему теста: ");
                        string thd = Console.ReadLine();
                        Console.Write("Введите оценку: ");
                        int grd = int.Parse(Console.ReadLine());
                        int index = 0;
                        var b = (dic1.Values).ToArray();    //присваем коллекцию значений в массив
                        foreach (var item in b)
                        {
                            if ((thd == b[index].Theme) && (grd == b[index].Grade))
                            {
                                b[index] = null;
                            }
                            index++;
                        }
                        index = 0;
                        st1.Clear();        //очищение стэков и словарей
                        st2.Clear();
                        dic1.Clear();
                        dic2.Clear();
                        foreach (var item in b)
                        {
                            if (item != null)
                            {
                                Challenge new_bb = item.GetBase;
                                string new_aa = new_bb.ToString();
                                st1.Push(new_bb);
                                st2.Push(new_aa);
                                try
                                {
                                    dic1.Add(new_bb, item);
                                    dic2.Add(new_aa, item);
                                }
                                catch
                                {

                                }
                            }
                        }
                        break;
                    case "3":
                        Console.Clear();
                        foreach (var item in st2)
                            Console.WriteLine(item);
                        Console.Write("Нажмите Enter, чтобы продолжить");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Поиск первого элемента");
                        Console.ForegroundColor = ConsoleColor.White;
                        sw.Start();     //начало таймера
                        if (st1.Contains(first))    //определяет содержится ли объект в стэке
                        {
                            sw.Stop();  //остановка таймера
                            Console.WriteLine($"Stack<Challenge> : {sw.Elapsed}");  //вывод таймера
                        }
                        sw.Reset();     //обнуление таймера
                        sw.Start();
                        if (st2.Contains(first.ToString())) //определяет содержится ли строка из объекта в стэке
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<string> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsKey(first))    //опеределяет содержится ли объект в словаре по ключу
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Challenge, Test> | ContainsKey : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsValue(firstV))     //определяет содержится ли объект в словаре по значению
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Challenge, Test> | ContainsValue : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic2.ContainsKey(first.ToString()))     //определяет содержится ли строка в словаре по ключу
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<string, Test> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Поиск срединного элемента");
                        Console.ForegroundColor = ConsoleColor.White;
                        sw.Start();
                        if (st1.Contains(middle))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<Challenge> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (st2.Contains(middle.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<string> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsKey(middle))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Challenge, Test> | ContainsKey : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsValue(middleV))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Challenge, Test> | ContainsValue : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic2.ContainsKey(middle.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<string, Test> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Поиск последнего элемента");
                        Console.ForegroundColor = ConsoleColor.White;
                        sw.Start();
                        if (st1.Contains(end))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<Challenge> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (st2.Contains(end.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<string> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsKey(end))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Challenge, Test> | ContainsKey : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsValue(endV))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Challenge, Test> | ContainsValue : {sw.Elapsed}");
                        }
                        sw.Reset();
                        sw.Start();
                        if (dic2.ContainsKey(end.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<string, Test> : {sw.Elapsed}");
                        }
                        sw.Reset();
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Поиск элемента не из коллекции");
                        Console.ForegroundColor = ConsoleColor.White;
                        sw.Start();
                        if (st1.Contains(outof))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<Challenge> : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine("Не найден!");
                        sw.Reset();
                        sw.Start();
                        if (st2.Contains(outof.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Stack<string> : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine("Не найден!");
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsKey(outof))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Challenge, Test> : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine("Не найден!");
                        sw.Reset();
                        sw.Start();
                        if (dic1.ContainsValue(outofV))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<Challenge, Test> | ContainsValue : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine("Не найден!");
                        sw.Reset();
                        sw.Start();
                        if (dic2.ContainsKey(outof.ToString()))
                        {
                            sw.Stop();
                            Console.WriteLine($"Dictionary<string, Test> : {sw.Elapsed}");
                        }
                        else
                            Console.WriteLine("Не найден!");
                        sw.Reset();
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить, нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "5":
                        Environment.Exit(0);    //прекращение работы программы 
                        break;
                }
            } while (true);
        }
    }
}
