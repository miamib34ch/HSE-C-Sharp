namespace Lab10_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t1 = new Test("How to make classes", 10);                                      //первая часть лабораторной     
            Exam e1 = new Exam("Algebra", 9);
            FinalExam f1 = new FinalExam("Medical doctor", 8);
            Challenge[] arr = { t1, e1, f1 };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Демонстрация работы виртуальных методов:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Challenge s in arr)
            {
                s.Show();
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Демонстрация работы не виртуальных методов:");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (Challenge s in arr)
            {
                s.Show1();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Программа работает неправильно без виртуальных методов (выводит не всю информацию), " +
                "\nпотому что метод Show1, который мы используем, он определяется для класса Challenge, а не для классов элементов, " +
                "\nведь массив типа Challenge и все его элементы определяются таким же типом." +
                "\nВиртуальные методы же позволяют программе понять к какому классу относится объект" +
                "\nи используется уже метод, прописанный внутри класса.");
            Console.WriteLine();
            Console.Write("Нажмите, чтобы перейти ко второй части: ");
            Console.ReadLine();
            Console.Clear();                                                                    //вторая часть лабораторной
            string select = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Выберете запрос:" +
                    "\n1. Сколько всего тестов?" +
                    "\n2. Есть ли экзамен по алгебре?" +
                    "\n3. Какая оценка за выпускной экзамен?" +
                    "\n4. Завершить вторую часть, перейти к третьей");
                select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Request1(arr);
                        Console.Write("Нажмите, для перехода к меню: ");
                        Console.ReadLine();
                        break;
                    case "2":
                        Request2(arr);
                        Console.Write("Нажмите, для перехода к меню: ");
                        Console.ReadLine();
                        break;
                    case "3":
                        Request3(arr);
                        Console.Write("Нажмите, для перехода к меню: ");
                        Console.ReadLine();
                        break;
                }
            } while (select != "4");
            Console.Clear();                                                                    //третья часть лабораторной 
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Вывод 3 случайных объектов иерархии и одного отдельного класса");
            Console.ForegroundColor = ConsoleColor.White;
            IInit[] mas = new IInit[4];
            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        Test t2 = new Test();
                        t2 = (Test)t2.Init();
                        mas[0] = t2;
                        break;
                    case 1:
                        Exam e2 = new Exam();
                        e2 = (Exam)e2.Init();
                        mas[1] = e2;
                        break;
                    case 2:
                        FinalExam f2 = new FinalExam();
                        f2 = (FinalExam)f2.Init();
                        mas[2] = f2;
                        break;
                    case 3:
                        Student s1 = new Student();
                        s1 = (Student)s1.Init();
                        mas[3] = s1;
                        break;
                }
            }
            foreach (var item in mas)
            {
                item.Show();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Нажмите, чтобы продолжить: ");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Сортировка массива из первой части (имена испытаний по алфавиту)");
            Console.ForegroundColor = ConsoleColor.White;
            Array.Sort(arr);
            foreach (var item in arr)
            {
                item.Show();
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Сортировка массива из первой части (оценки испытаний по возрастанию)");
            Console.ForegroundColor = ConsoleColor.White;
            Array.Sort(arr, new SortByGrade());
            foreach (var item in arr)
            {
                item.Show();
                Console.WriteLine();
            }
            Console.Write("Нажмите, чтобы продолжить: ");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Клонирование");
            Console.ForegroundColor = ConsoleColor.White;
            Student real = new Student("ReaL", 99999);
            real.Show();
            Student clone = (Student)real.Clone();
            clone.Name = "not" + clone.Name;
            clone.id.number = 66666;
            Console.WriteLine();
            clone.Show();
            Console.WriteLine();
            real.Show();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Копирование");
            Console.ForegroundColor = ConsoleColor.White;
            Student copy = (Student)real.ShalowCopy();
            copy.Show();
            Console.WriteLine();
            copy.Name = "copyof" + copy.Name;
            copy.id.number = 11111;
            copy.Show();
            Console.WriteLine();
            real.Show();
            Console.WriteLine();
            Console.WriteLine("Когда мы клонировали и меняли значения, это не отражалось на изначальном объекте," +
                "\nпри поверхностном копировании, если мы изменяем значение у копии, меняется значение и у изначального объекта." +
                "\nЭто связано с тем, что копируется адрес, и когда мы изменяем, изменяется то, на что этот адрес указывает. ");
            Console.WriteLine();
            Console.Write("Нажмите, чтобы завершить: ");
            Console.ReadLine();
        }
        static void Request1(Challenge[] arr)                                         //метод выполняющий первый запрос
        {
            int count = 0;
            foreach (Challenge s in arr)
                if (s is Test) count++;                                               //используется ключевое слово is, проверяю относится ли s к типу Test 
            Console.WriteLine($"Всего {count} тест(ов)");
        }
        static void Request2(Challenge[] arr)                                        //метод выполняющий второй запрос
        {
            Exam tmp = new Exam("", 0);
            foreach (Challenge s in arr)
            {
                tmp = s as Exam;                                                     //использую ключевое слово as, пробую s привести к типу Exam
                if (tmp != null)
                {
                    if (tmp.Subject == "Algebra")
                        Console.WriteLine("Есть экзамен по алгебре!");
                    break;
                }
            }
        }
        static void Request3(Challenge[] arr)                                        //метод выполняющий третий запрос
        {
            FinalExam tmp = new FinalExam("Medical doctor", 0);
            foreach (Challenge s in arr)
                if (s is FinalExam)
                    tmp = s as FinalExam;
            Console.WriteLine($"Оценка за выпускной экзамен: {tmp.Grade}");

        }
    }
}