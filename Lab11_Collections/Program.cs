using Lab10_Interfaces;
using System.Collections;

namespace Lab11_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();                                    //Функция запускающая первое задание
            Task2();                                    //Функция запускающая второе задание
            Console.Title = "Задание 3";                //Изменение названия консоли
            TestCollections a = new TestCollections();  //Создание экземпляра класса TestCollections
        }
        #region Task1
        static void Task1()
        {
            Console.Title = "Задание 1";
            Hashtable coll_hash = new Hashtable();                  //объект коллекции Хэш-таблица (комбинация массива и списка)
            coll_hash.Add("bio", new Test("Мозг человека", 10));     //добавление в коллекцию объекта
            coll_hash.Add("alg", new Test("Сложные функции", 10));
            coll_hash.Add("bio_e", new Exam("Биология", 10));
            coll_hash.Add("alg_e", new Exam("Алгебра", 10));
            coll_hash.Add("bio_f", new FinalExam("Биолог", 10));
            coll_hash.Add("alg_f", new FinalExam("Математик", 10));
            bool not_end = true;                                    //переменная для бесконечного цикла
            do
            {
                Console.Clear();
                Console.WriteLine("Меню:" +
                    "\n1.Добавить объекты" +
                    "\n2.Удалить объекты" +
                    "\n3.Запросить количество тестов" +
                    "\n4.Запросить количество экзаменов с оценкой 10" +
                    "\n5.Запросить печать всех FinalExam" +
                    "\n6.Вывести все объекты коллекции на печать" +
                    "\n7.Выполнить клонирование коллекции" +
                    "\n8.Сортировка по имени испытания по алфавиту" +
                    "\n9.Поиск объекта" +
                    "\n10.Завершить задание 1");
                switch (Console.ReadLine())
                {
                    case "1":                                       //первое действие          
                        Console.Clear();
                        Console.Write("Укажите число добавляемых элементов: ");
                        int size = int.Parse(Console.ReadLine());
                        for (int i = 0; i < size; i++)
                        {
                            Console.Write("Укажите какой объект вы хотите добавить? (Test / Exam / FinalExam): ");
                            switch (Console.ReadLine())
                            {
                                case "Test":
                                    Console.Write("Укажите ключ объекта: ");
                                    string key = Console.ReadLine();
                                    Console.Write("Укажите тему теста: ");
                                    string theme = Console.ReadLine();
                                    Console.Write("Укажите оценку теста: ");
                                    int grade = int.Parse(Console.ReadLine());
                                    coll_hash.Add(key, new Test(theme, grade));
                                    break;
                                case "Exam":
                                    Console.Write("Укажите ключ объекта: ");
                                    key = Console.ReadLine();
                                    Console.Write("Укажите предмет экзамена: ");
                                    string sub = Console.ReadLine();
                                    Console.Write("Укажите оценку теста: ");
                                    grade = int.Parse(Console.ReadLine());
                                    coll_hash.Add(key, new Exam(sub, grade));
                                    break;
                                case "FinalExam":
                                    Console.Write("Укажите ключ объекта: ");
                                    key = Console.ReadLine();
                                    Console.Write("Укажите специальность: ");
                                    string spec = Console.ReadLine();
                                    Console.Write("Укажите оценку теста: ");
                                    grade = int.Parse(Console.ReadLine());
                                    coll_hash.Add(key, new FinalExam(spec, grade));
                                    break;
                            }
                        }
                        break;
                    case "2":                                           //второе действие
                        Console.Clear();
                        if (coll_hash.Count == 0)                       //если в коллекции нет пар ключа и значения
                        {
                            Console.WriteLine("Коллекция пуста");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.Write("Укажите ключ: ");
                            string key = Console.ReadLine();
                            coll_hash.Remove(key);                      //удаление пары по ключу
                            break;
                        }
                    case "3":                                           //третье действие
                        Console.Clear();
                        int count = 0;
                        foreach (var item in coll_hash.Values)          //для всех значений в коллекции значений
                        {
                            if (item is Test)                           //относится ли к Test
                                count++;
                        }
                        Console.WriteLine($"Количество тестов = {count}");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "4":                                            //четвёртое действие
                        Console.Clear();
                        int count2 = 0;
                        foreach (var item in coll_hash.Values)
                        {
                            if (item is Exam)
                            {
                                if (((Exam)item).Grade == 10)
                                {
                                    count2++;
                                }
                            }
                        }
                        Console.WriteLine($"Количество экзаменов с оценкой 10 = {count2}");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "5":                                            //пятое дейсвтвие
                        Console.Clear();
                        foreach (var item in coll_hash.Values)
                        {
                            if (item is FinalExam)
                            {
                                ((FinalExam)item).Show();
                                Console.WriteLine("");
                            }
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "6":                                            //шестое действие
                        Console.Clear();
                        foreach (var item in coll_hash.Values)
                        {
                            ((Challenge)item).Show();
                            Console.WriteLine("");
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "7":                                           //седьмое действие
                        Console.Clear();
                        Hashtable clon = (Hashtable)coll_hash.Clone();  //клонирование, присваивает ссылку
                        Console.WriteLine($"Количество ссылок в клоне: {clon.Count}");
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "8":                                           //восьмое действие
                        Console.Clear();
                        Challenge[] SortedArr = new Challenge[coll_hash.Count];
                        int index = 0;
                        foreach (var item in coll_hash.Values)
                        {
                            SortedArr[index] = (Challenge)item;
                            index++;
                        }
                        Array.Sort(SortedArr);
                        foreach (Challenge item in SortedArr)
                        {
                            item.Show();
                            Console.WriteLine();
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "9":                                           //девятое действие
                        Console.Clear();
                        Console.Write("Введите ключ объекта: ");
                        string key_obj = Console.ReadLine();
                        Console.WriteLine("");
                        ((Challenge)coll_hash[key_obj]).Show();     //поиск по ключу и вывод
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "10":                                          //десятое действие
                        not_end = false;
                        break;
                    default:                                            //если выбрано не 1-10
                        break;
                }
            } while (not_end);
        }
        #endregion
        #region Task2
        static void Task2()
        {
            Console.Title = "Задание 2";
            Queue<Challenge> coll_q = new Queue<Challenge>();           //коллекция очередь (первый вошёл и первый вышел) для типа Challenge
            coll_q.Enqueue(new Test("Мозг человека", 10));              //добавление объекта в очередь
            coll_q.Enqueue(new Test("Сложные функции", 10));
            coll_q.Enqueue(new Exam("Биология", 10));
            coll_q.Enqueue(new Exam("Алгебра", 10));
            coll_q.Enqueue(new FinalExam("Биолог", 10));
            coll_q.Enqueue(new FinalExam("Математик", 10));
            bool not_end_2 = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Меню:" +
                    "\n1.Добавить объекты" +
                    "\n2.Удалить первый объект" +
                    "\n3.Запросить количество тестов" +
                    "\n4.Запросить количество экзаменов с оценкой 10" +
                    "\n5.Запросить печать всех FinalExam" +
                    "\n6.Вывести все объекты коллекции на печать" +
                    "\n7.Выполнить клонирование коллекции" +
                    "\n8.Сортировка по имени испытания по алфавиту" +
                    "\n9.Поиск объекта" +
                    "\n10.Завершить задание 2");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Укажите число добавляемых элементов: ");
                        int size_2 = int.Parse(Console.ReadLine());
                        for (int i = 0; i < size_2; i++)
                        {
                            Console.Write("Укажите какой объект вы хотите добавить? (Test / Exam / FinalExam): ");
                            switch (Console.ReadLine())
                            {
                                case "Test":
                                    Console.Write("Укажите тему теста: ");
                                    string theme = Console.ReadLine();
                                    Console.Write("Укажите оценку теста: ");
                                    int grade = int.Parse(Console.ReadLine());
                                    coll_q.Enqueue(new Test(theme, grade));
                                    break;
                                case "Exam":
                                    Console.Write("Укажите предмет экзамена: ");
                                    string sub = Console.ReadLine();
                                    Console.Write("Укажите оценку теста: ");
                                    grade = int.Parse(Console.ReadLine());
                                    coll_q.Enqueue(new Exam(sub, grade));
                                    break;
                                case "FinalExam":
                                    Console.Write("Укажите специальность: ");
                                    string spec = Console.ReadLine();
                                    Console.Write("Укажите оценку теста: ");
                                    grade = int.Parse(Console.ReadLine());
                                    coll_q.Enqueue(new FinalExam(spec, grade));
                                    break;
                            }
                        }
                        break;
                    case "2":
                        Console.Clear();
                        if (coll_q.Count == 0)
                        {
                            Console.WriteLine("Коллекция пуста");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            coll_q.Dequeue();                       //удаляет самый первый объект в очереди
                            break;
                        }
                    case "3":
                        Console.Clear();
                        int count = 0;
                        foreach (var item in coll_q)
                        {
                            if (item is Test)
                                count++;
                        }
                        Console.WriteLine($"Количество тестов = {count}");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Clear();
                        int count2 = 0;
                        foreach (var item in coll_q)
                        {
                            if (item is Exam)
                            {
                                if (((Exam)item).Grade == 10)
                                {
                                    count2++;
                                }
                            }
                        }
                        Console.WriteLine($"Количество экзаменов с оценкой 10 = {count2}");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.Clear();
                        foreach (var item in coll_q)
                        {
                            if (item is FinalExam)
                            {
                                ((FinalExam)item).Show();
                                Console.WriteLine("");
                            }
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "6":
                        Console.Clear();
                        foreach (var item in coll_q)
                        {
                            item.Show();
                            Console.WriteLine("");
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "7":
                        Console.Clear();
                        Queue clon_q = new Queue(coll_q);                                   //копия
                        Console.WriteLine($"Количество ссылок в клоне: {clon_q.Count}");
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "8":
                        Console.Clear();
                        Challenge[] SortedArr = new Challenge[coll_q.Count];
                        int index = 0;
                        foreach (var item in coll_q)
                        {
                            SortedArr[index] = item;
                            index++;
                        }
                        Array.Sort(SortedArr);
                        foreach (Challenge item in SortedArr)
                        {
                            item.Show();
                            Console.WriteLine();
                        }
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "9":
                        Console.Clear();
                        Console.Write("Введите номер объекта: ");
                        int key_obj = int.Parse(Console.ReadLine());
                        Console.WriteLine("");
                        (coll_q.ToArray())[key_obj - 1].Show();               //очередь превращает в массив
                        Console.WriteLine("");
                        Console.Write("Чтобы продолжить нажмите Enter");
                        Console.ReadLine();
                        break;
                    case "10":
                        not_end_2 = false;
                        break;
                    default:
                        break;
                }
            } while (not_end_2);
        }
        #endregion
    }
}