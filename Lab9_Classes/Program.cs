using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool end = false;
            bool sozdan = false;
            bool sozdan_k = false;
            DiapasonArray zadacha3_r = new DiapasonArray();
            DiapasonArray zadacha3_k = new DiapasonArray();
            do
            {
                Console.WriteLine("Меню:" +
                    "\n1. Проверить задачу 1" +
                    "\n2. Проверить задачу 2" +
                    "\n3. Проверить задачу 3" +
                    "\n4. Посмотреть массив объекта согласно индексу" +
                    "\n0. Выход");
                int check = Enter_Int("Выберите задачу: ");
                switch (check)
                {
                    #region задача 1
                    case 1:
                        Diapason zadacha1 = new Diapason();
                        zadacha1.Print();
                        break;
                    #endregion
                    #region задача 2
                    case 2:
                        Diapason zadacha2 = new Diapason();
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Пример работы унарной операции ++ (увеличивает координаты диапазона на 1):");
                        Console.ResetColor();
                        zadacha2.Print();
                        (zadacha2++).Print();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Пример работы унарной операции ! (вычисляет длину диапазона): " + !zadacha2);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Пример работы бинарной операции + int d (увеличивает координаты на число d, например 7):");
                        Console.ResetColor();
                        (zadacha2 + 7).Print();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Пример работы бинарной операции < int d (выводит true, если число попадает в диапазон, false, если нет; возьмём 8): " + (zadacha2 < 8));
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Пример работы операции приведения типа int(явная) (результат - целая часть X): " + (int)zadacha2);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Пример работы операции приведения типа double(неявная) (результат - Y): " + (double)zadacha2);
                        Console.ResetColor();
                        break;
                    #endregion
                    #region задача 3
                    case 3:
                        Console.WriteLine("\n1. Заполнить датчиком случайных чисел" +
                            "\n2. С клавиатуры" +
                            "\nДля выхода введите любую другую цифру");
                        int check2 = Enter_Int("Выберите способ ввода: ");
                        switch (check2)
                        {
                            case 1:
                                zadacha3_r = new DiapasonArray(Enter_Int("Введите размер массива: "));
                                sozdan = true;
                                break;
                            case 2:
                                zadacha3_k = new DiapasonArray(Enter_Int("Введите размер массива: "), 1);
                                sozdan = true;
                                sozdan_k = true;
                                break;
                        }
                        break;
                    #endregion
                    #region индексатор
                    case 4:
                        if (sozdan == true)
                        {
                            int i = Enter_Int("Введите индекс элемента, который хотите увидить: ");
                            if (sozdan_k)
                                zadacha3_k[i].Print();
                            else
                                zadacha3_r[i].Print();
                        }
                        else
                            Console.WriteLine("Массив ещё не создан и не заполнен!");
                        break;
                    #endregion
                    case 0:
                        end = true;
                        break;
                }
            } while (end == false);
        }

        static int Enter_Int(string inf)                                               //функция для ввода, с проверкой на integer
        {
            Console.Write(inf);
            int num = 0;
            bool a = false;
            do
            {
                try
                {
                    num = int.Parse(Console.ReadLine());
                    a = true;
                }
                catch
                {
                    Console.WriteLine("Ошибка - введено не число, либо оно не целочисленное!");
                    Console.WriteLine("Повторите попытку!");
                    Console.Write("Введите целочисленное число: ");
                }
            } while (a == false);
            return num;
        }

        public static double Enter_Double(string inf)                                         //функция для ввода, с проверкой на double
        {
            Console.Write(inf);
            double num = 0;
            bool a = false;
            do
            {
                try
                {
                    num = double.Parse(Console.ReadLine());
                    a = true;
                }
                catch
                {
                    Console.WriteLine("Ошибка - введено не число!");
                    Console.WriteLine("Повторите попытку!");
                    Console.Write("Введите число: ");
                }
            } while (a == false);
            return num;
        }
    }
}