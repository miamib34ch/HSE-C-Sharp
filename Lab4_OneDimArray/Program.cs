using static System.Console;

string menu = "-1"; //инициализация переменной, отвечающей за переключение меню
int[] arr = new int[0]; //инициализация массива
int size = -1; //инициализация переменной, отвечающей за размер массива
Random a = new Random(0); //инициализация целочисленного случайного числа
do
{
    Clear(); //очищает консоль
    WriteLine("Выполнил Полыгалов Богдан, вариант 5");
    WriteLine();
    WriteLine("1. Сформировать массив");
    WriteLine("2. Печать массива");
    WriteLine("3. Удаление чётных элементов из массива");
    WriteLine("4. Добавление K элементов в начало массива");
    WriteLine("5. Поиск первого чётного элемента в массиве");
    WriteLine("6. Сортировка массива: Простой выбор");
    WriteLine("7. Перестановка элементов в массиве: чётные в начало, нечётные в конец");
    WriteLine("8. Выход");
    WriteLine();
    Write("Введите номер выполняемого действия: ");
    menu = ReadLine();//изменение значения меню
    switch (menu) //переключение меню
    {
        #region case 1
        case "1": //начало кейса
            {
                WriteLine();
                Write("Введите размер массива: ");
                bool ok1 = false; //инициализация переменной , отвечающей за выход из цикла
                do //начало цикла
                {
                    try
                    {
                        size = int.Parse(ReadLine()); //ввод размера массива
                        ok1 = true; //для выхода из цикла
                        if (size <= 0) //отброс не нужный значений
                        {
                            if (size == 0)
                            {
                                WriteLine("Пустой массив!");
                                Write("Для продолжения нажмите любую клавишу:");
                                ReadLine();
                            }
                            else
                            {
                                WriteLine("Введено отрицательное число!");
                                Write("Для продолжения нажмите любую клавишу:");
                                ReadLine();
                            }
                        }
                        else
                        {
                            arr = new int[size]; //присваеваем массиву новый размер
                            WriteLine();
                            WriteLine("Укажите способ ввода массива:");
                            WriteLine("1. Ввод с клавиатуры");
                            WriteLine("2. Присвоить элементам массива случайные числа");
                            Write("Введите номер выполняемого действия: ");
                            bool ok = false, ok2 = false; //для цикла
                            do //начало цикла
                            {
                                string sposob = ReadLine(); //ввод способа ввода массива
                                if (sposob == "1")
                                {
                                    ok = true; //для выхода из цикла
                                    for (int i = 0; i < size; i++)
                                    {
                                        do //начало цикла
                                        {
                                            try
                                            {
                                                Write($"Введите {i + 1}-элемент массива: ");
                                                arr[i] = int.Parse(ReadLine()); //ввод элементов массива
                                                ok2 = true; //для выхода из массива
                                            }
                                            catch //обработка исключения 
                                            {
                                                WriteLine("Введено не число!");
                                            }
                                        } while (ok2 != true); //конец цкила
                                    }
                                }
                                if (sposob == "2")
                                {
                                    ok = true; //для выхода из цикла
                                    for (int i = 0; i < size; i++)
                                    {
                                        arr[i] = a.Next(1, 100); //присвоение элементам массива случайного значения от 1 до 100
                                    }
                                }
                                if ((sposob != "1") && (sposob != "2")) //исключение
                                {
                                    WriteLine("Введено не верное значение");
                                    Write("Введите номер выполняемого действия: ");
                                }
                            } while (ok != true); //конец цикла
                            WriteLine();
                            WriteLine("Изначальный массив:");
                            for (int j = 0; j < size; j++)
                            {
                                Write($"{arr[j]} "); //ввыод массива
                            }
                            WriteLine();
                            Write("Для продолжения нажмите любую клавишу:");
                            ReadLine(); //ввод для продолжения программы
                        }
                    }
                    catch //обработка исключения
                    {
                        WriteLine("Введено не число!");
                        Write("Введите размер массива: ");
                    }
                } while (ok1 != true); //конец цикла
                break; //завершение кейса
            }
        #endregion
        #region case 2
        case "2": //начало кейса
            {
                if (size == -1) //исключение на случай, если массив не сформирован
                {
                    WriteLine("Массив не сформирован!");
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine(); //ввод для продолжения программы
                }
                else
                {
                    for (int i = 0; i < size; i++)
                    {
                        Write($"{arr[i]} "); //вывод массива
                    }
                    WriteLine();
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine(); //ввод для продолжения программы
                }
                break;
            }
        #endregion
        #region case 3
        case "3":
            {
                if (size != -1)
                {
                    int count = 0;
                    for (int i = 0; i < size; i++)
                    {
                        if (arr[i] % 2 != 0)
                            count++;
                    }
                    if (count != size)
                    {
                        int[] temp = new int[count];
                        int j = 0;
                        for (int i = 0; i < size; i++)
                            if (arr[i] % 2 != 0)
                            {
                                temp[j] = arr[i];
                                j++;
                            }
                        arr = temp;
                        size = count;
                        if (size != 0)
                        {
                            WriteLine("Массив после удаления чётных элементов:");
                            for (int i = 0; i < size; i++)
                                Write(arr[i] + " ");
                            WriteLine();
                            Write("Для продолжения нажмите любую клавишу:");
                            ReadLine();
                        }
                        else
                        {
                            WriteLine("Массив стал пустым!");
                            Write("Для продолжения нажмите любую клавишу:");
                            ReadLine();
                        }
                    }
                    else
                    {
                        WriteLine("В массиве нет чётных элементов! Он остался без изменений.");
                        Write("Для продолжения нажмите любую клавишу:");
                        ReadLine();
                    }
                }
                else
                {
                    WriteLine("Массив не сформирован.");
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine();
                }
                break;
            }
        #endregion
        #region case 4
        case "4":
            {
                if (size != -1)
                {
                    Write("Введите количество добавляемых элементов в начало массива: ");
                    try
                    {
                        int K = int.Parse(ReadLine());
                        if (K > 0)
                        {
                            int[] temp = new int[size + K];
                            for (int i = 0; i < size + K; i++)
                            {
                                if (i < K)
                                    temp[i] = a.Next(1, 100);
                                else
                                    temp[i] = arr[i - K];
                            }
                            arr = temp;
                            size += K;
                            WriteLine("Массив после добавления " + K + " элементов в начало массива:");
                            for (int i = 0; i < size; i++)
                                Write(arr[i] + " ");
                            WriteLine();
                            Write("Для продолжения нажмите любую клавишу:");
                            ReadLine();
                        }
                        else
                        {
                            WriteLine("В массив ничего не добавляется! Он остался без изменений.");
                            Write("Для продолжения нажмите любую клавишу:");
                            ReadLine();
                        }
                    }
                    catch
                    {
                        WriteLine("Введено не число!");
                        Write("Для продолжения нажмите любую клавишу:");
                        ReadLine();
                    }
                }
                else
                {
                    WriteLine("Массив не сформирован, добавление невозможно!");
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine();
                }
                break;
            }
        #endregion
        #region case 5
        case "5":
            {
                int first = -1;
                if (size == -1)
                {
                    WriteLine("Массив не сформирован!");
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine();
                }
                else
                {
                    for (int i = 0; i < size; i++)
                    {
                        if (arr[i] % 2 == 0)
                        {
                            first = arr[i];
                            break;
                        }
                        else
                        {
                            WriteLine("В массиве нет чётных чисел!");
                        }
                    }
                    if (first != -1)
                        WriteLine($"Первый чётный элемент в массиве: {first}");
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine();
                }
                break;
            }
        #endregion
        #region case 6
        case "6":
            {
                if (size == -1)
                {
                    WriteLine("Массив не сформирован!");
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine();
                }
                else
                {
                    for (int j = 0; j < size; j++)
                    {
                        int tmp = arr[j];
                        int nomer = j;
                        for (int i = 0 + j; i < size; i++)
                        {
                            if (arr[i] < tmp)
                            {
                                tmp = arr[i];
                                nomer = i;
                            }
                        }
                        arr[nomer] = arr[j];
                        arr[j] = tmp;
                    }
                    WriteLine("Отсортированный массив: ");
                    for (int i = 0; i < size; i++)
                        Write($"{arr[i]} ");
                    WriteLine();
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine();
                }
                break;
            }
        #endregion
        #region case 7
        case "7":
            {
                if (size == -1)
                {
                    WriteLine("Массив не сформирован!");
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine();
                }
                else
                {
                    int i, j, tmp;
                    for (i = 0, j = size - 1; i < j;)
                    {
                        if (arr[i] % 2 != 0 && arr[j] % 2 == 0)
                        {
                            tmp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = tmp;
                        }
                        if (arr[i] % 2 == 0)
                        {
                            i += 1;
                        }
                        if (arr[j] % 2 != 0)
                        {
                            j -= 1;
                        }
                    }
                    WriteLine("Массив с перестановкой:");
                    for (int k = 0; k < size; k++)
                        Write($"{arr[k]} ");
                    WriteLine();
                    Write("Для продолжения нажмите любую клавишу:");
                    ReadLine();
                }
                break;
            }
            #endregion
    }
} while (menu != "8");