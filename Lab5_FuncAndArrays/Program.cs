using static System.Console;

int userChoise = -1, check = 0, jagSize = 0; // 1 - размер массива, 2 - меню

WriteLine("Одномерный массив.");     // создание одномерного массива
int[] oDimArr = CreateOdimArr();
Clear();

WriteLine("Двумерный массив.");      // создание двумерного массива
int[,] tDimArr = CreateTdimArr();
Clear();

WriteLine("Рваный массив.");     // создание рваного массива
int[][] jagArr = CreateJagArr(out jagSize);
Clear();


while (userChoise != 0)
{
    WriteLine();        // текстовое меню
    WriteLine("Выберите необходимое действие:");
    WriteLine("1 - Заполнить массив.");
    WriteLine("2 - Одномерный массив.");
    WriteLine("3 - Двумерный массив.");
    WriteLine("4 - Рваный массив.");
    WriteLine("0 - Завершить работу программы.");
    WriteLine("Любое иное целое число - очистить экран.");
    WriteLine();
    userChoise = GetInteger();  // входные данные (2)

    switch (userChoise)         // меню
    {
        case 1:     // заполнение массива

            WriteLine("1 - Заполнить одномерный массив.");
            WriteLine("2 - Заполнить двумерный массив.");
            WriteLine("3 - Заполнить рваный массив.");

            check = GetInteger();

            switch (check)
            {
                case 1:     // заполняет одномерный массив
                    oDimArr = FillOdimArr(ref oDimArr);
                    break;
                case 2:     // заполняет двумерный массив
                    tDimArr = FillTdimArr(ref tDimArr);
                    break;
                case 3:     // заполняет рваный массив
                    jagArr = FillJagArr(ref jagArr);
                    break;
                default:
                    break;
            }
            break;
        case 2:     // Одномерный массив

            WriteLine("1 - Удалить все чётные числа из массива.");
            WriteLine("2 - Вывести массив.");

            check = GetInteger();

            switch (check)
            {
                case 1:     // удаление чётных
                    if (CheckMass(ref userChoise, ref oDimArr, ref tDimArr, ref jagArr) == false)       // проверка на пустоту
                    {
                        break;
                    }
                    else
                    {
                        oDimArr = RemoveEven(ref oDimArr);      // удаление чётных
                        if (CheckMass(ref userChoise, ref oDimArr, ref tDimArr, ref jagArr) == false)       // проверка на пустоту
                        {
                            break;
                        }
                        else
                        {
                            PrintMass(ref oDimArr, ref tDimArr, ref jagArr, ref userChoise, ref jagSize);       // вывести массив
                        }
                        break;
                    }
                case 2:     // вывод массива.
                    if (CheckMass(ref userChoise, ref oDimArr, ref tDimArr, ref jagArr) == false)       // проверка на пустоту
                    {
                        break;
                    }
                    else
                    {
                        PrintMass(ref oDimArr, ref tDimArr, ref jagArr, ref userChoise, ref jagSize);       // вывести массив
                    }
                    break;
                default:
                    break;
            }
            break;
        case 3:     // Двумерный массив

            WriteLine("1 - Добавить строку в начало массива.");
            WriteLine("2 - Вывести массив.");

            check = GetInteger();

            switch (check)
            {
                case 1:     // добавить строки в начало массива
                    if (CheckMass(ref userChoise, ref oDimArr, ref tDimArr, ref jagArr) == false)       // проверка на пустоту
                    {
                        break;
                    }
                    else
                    {
                        tDimArr = AddLineMass(ref tDimArr);     // добавление строки в начало
                        PrintMass(ref oDimArr, ref tDimArr, ref jagArr, ref userChoise, ref jagSize);     // вывести массив
                    }
                    break;
                case 2:     // вывод массива
                    if (CheckMass(ref userChoise, ref oDimArr, ref tDimArr, ref jagArr) == false)       // проверка на пустоту
                    {
                        break;
                    }
                    else
                    {
                        PrintMass(ref oDimArr, ref tDimArr, ref jagArr, ref userChoise, ref jagSize);     // вывести массив
                    }
                    break;
            }
            break;
        case 4:     // Рваный массив
            WriteLine("1 - Удалить строку с заданным номером.");
            WriteLine("2 - Вывести массив.");

            check = GetInteger();

            switch (check)
            {
                case 1:     // удаление строк с заданным номером
                    if (CheckMass(ref userChoise, ref oDimArr, ref tDimArr, ref jagArr) == false)       // проверка на пустоту
                    {
                        break;
                    }
                    else
                    {
                        Write("Введите количество строк: ");
                        int proverka = 0;
                        int cicle = int.Parse(ReadLine());
                        do
                        {
                            for (int i = 0; i < cicle; i++)
                            {
                                jagArr = DeleteLineMass(ref jagArr, ArrSize("Введите номер строки, которую необходимо удалить: "));     // удаление строк
                                proverka++;
                            }
                        } while (proverka != cicle);
                        if (CheckMass(ref userChoise, ref oDimArr, ref tDimArr, ref jagArr) == false)       // проверка на пустоту
                        {
                            break;
                        }
                        else
                        {
                            PrintMass(ref oDimArr, ref tDimArr, ref jagArr, ref userChoise, ref jagSize);     // вывести массив
                        }
                    }
                    break;
                case 2:     // вывод массива
                    if (CheckMass(ref userChoise, ref oDimArr, ref tDimArr, ref jagArr) == false)       // проверка на пустоту
                    {
                        break;
                    }
                    else
                    {
                        PrintMass(ref oDimArr, ref tDimArr, ref jagArr, ref userChoise, ref jagSize);     // вывести массив
                    }
                    break;
            }
            break;
        default:    // Действие по умолчанию
            Clear();        // очистить консоль
            break;
    }
    WriteLine();
}

static int ArrSize(string msg)      // чтобы задать размер массива и числа, которые не должны быть <= 0
{
    int size = 0;
    Write(msg);
    while (size <= 0) // входные данные (1)
    {
        size = GetInteger();        // считывает число
        if (size <= 0)
        {
            Write("Введите целое число больше нуля: ");
        }
    }
    return size;        // возвращает число
}
static int[] CreateOdimArr()        // создаёт одномерный массив
{
    int[] arr = new int[ArrSize("Введите количество элементов массива: ")];      // считывает кол-во элементов в массиве
    return arr;     // возвращает одномерный массив
}
static int[] FillOdimArr(ref int[] oDimArr)     //заполняет одномерный массив
{
    int check = 0;

    WriteLine("1 - Заполнить массив с клавиатуры.");     // меню
    WriteLine("2 - Заполнить массив случайными числами.");

    check = GetInteger();
    switch (check)      // меню
    {
        case 1:     // заполнение с клавиатуры
            for (int i = 0; i < oDimArr.Length; i++)
            {
                WriteLine("Введите целое число: ");
                oDimArr[i] = GetInteger();
            }
            break;
        case 2:     // заполнение рандомом
            Random rnd = new Random();

            for (int i = 0; i < oDimArr.Length; i++)
            {
                oDimArr[i] = rnd.Next(0, 100);
            }
            break;
        default:
            break;
    }
    return oDimArr;     // возвращает заполненный одномерный массив
}
static int[,] CreateTdimArr()       // создаёт двумерный массив
{
    int[,] arr = new int[ArrSize("Введите количество строк массива: "), ArrSize("Введите количество столбцов массива: ")];
    return arr;
}
static int[,] FillTdimArr(ref int[,] tDimArr)       // заполняет двумерный массив
{
    int check = 0;

    WriteLine("1 - Заполнить массив с клавиатуры.");     // меню
    WriteLine("2 - Заполнить массив случайными числами.");

    check = GetInteger();
    switch (check)      // меню
    {
        case 1:     // заполнение с клавиатуры
            for (int i = 0; i < tDimArr.GetLength(0); i++)
            {
                for (int j = 0; j < tDimArr.GetLength(1); j++)
                {
                    WriteLine("Введите целое число: ");
                    tDimArr[i, j] = GetInteger();
                }
            }
            break;
        case 2:     // заполнение рандомом
            Random rnd = new Random();

            for (int i = 0; i < tDimArr.GetLength(0); i++)
            {
                for (int j = 0; j < tDimArr.GetLength(1); j++)
                {
                    tDimArr[i, j] = rnd.Next(0, 100);
                }
            }
            break;
        default:
            break;
    }
    return tDimArr;     // возвращает двумерный массив
}
static int[][] CreateJagArr(out int jagSize)        // создаёт рваный массив
{
    jagSize = ArrSize("Введите количество строк массива: ");
    int[][] arr = new int[jagSize][];
    Random rnd = new Random();
    for (int i = 0; i < jagSize; i++)
    {
        arr[i] = new int[rnd.Next(1, 100)]; // присвает случайное значение
    }
    return arr;     // возвращает рваный массив
}
static int[][] FillJagArr(ref int[][] jagArr)       // заполняет рваный массив
{
    int check = 1;

    WriteLine("1 - Заполнить массив с клавиатуры.");     // меню
    WriteLine("2 - Заполнить массив случайными числами.");

    check = GetInteger();
    switch (check)      // меню
    {
        case 1:     // заполнение с клавиатуры
            for (int i = 0; i < jagArr.Length; i++)
            {
                int columns = ArrSize("Введите количество столбцов массива: ");
                jagArr[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    WriteLine("Введите целое число: ");
                    jagArr[i][j] = GetInteger();
                }
            }

            WriteLine("Массив заполнен.");
            break;
        case 2:     // заполнение рандомом
            Random rnd = new Random();

            for (int i = 0; i < jagArr.Length; i++)
            {
                int columns = ArrSize("Введите количество столбцов массива: ");
                jagArr[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                    jagArr[i][j] = rnd.Next(0, 100);
            }
            WriteLine("Массив заполнен.");
            break;
        default:
            break;
    }
    return jagArr;
}
static bool CheckMass(ref int userChoise, ref int[] oDimArr, ref int[,] tDimArr, ref int[][] jagArr)        // проверка на пустоту
{
    bool k;
    k = true;
    WriteLine();
    switch (userChoise)
    {
        case 2:     // одномерный массив
            if (oDimArr.Length == 0)
            {
                WriteLine("Массив пустой!");
                k = false;
            }
            break;
        case 3:     // двумерный массив
            if (tDimArr.Length == 0)
            {
                WriteLine("Массив пустой!");
                k = false;
            }
            break;
        case 4:     // рваный массив
            if (jagArr.Length == 0)
            {
                WriteLine("Массив пустой!");
                k = false;
            }
            break;
    }
    return k;       // возвращает булевую переменную
}
static void PrintMass(ref int[] oDimArr, ref int[,] tDimArr, ref int[][] jagArr, ref int userChoise, ref int jagSize)     // вывести массив
{
    WriteLine();
    switch (userChoise)
    {
        case 2:     // одномерный массив
            for (int i = 0; i < oDimArr.Length; i++)
            {
                Write(oDimArr[i]);
            }
            break;
        case 3:     // двумерный массив
            for (int i = 0; i < tDimArr.GetLength(0); i++)
            {
                for (int j = 0; j < tDimArr.GetLength(1); j++)
                    Write(tDimArr[i, j].ToString() + " ");
                WriteLine();
            }
            break;
        case 4:     // рваный массив
            for (int i = 0; i < jagArr.Length; i++)
            {
                for (int j = 0; j < jagArr[i].Length; j++)
                    Write(jagArr[i][j].ToString() + " ");
                WriteLine();
            }
            break;
    }
}
static int[] RemoveEven(ref int[] arr)     // удалить все чётные в одномерном массиве
{
    int k = 0;
    for (int i = 0; i < arr.GetLength(0); i++)      // запоминает сколько чисел убрать
    {
        if ((arr[i] % 2) == 0)
        {
            k++;
        }
    }

    int[] plusArr = new int[arr.GetLength(0) - k];  // новый массив
    k = 0;

    for (int i = 0; i < arr.GetLength(0); i++)      // заполнение нового массива элементами без чётных
    {
        if ((arr[i] % 2) != 0)
        {
            plusArr[k] = arr[i];
            k++;
        }
    }
    return plusArr;     // возвращает изменённый массив
}
static int[,] AddLineMass(ref int[,] tDimArr)     // добавить строку в начало двумерного массива
{
    int n = 0, k = 0;
    Random rnd = new Random();      // рандом
    n = ArrSize("Введите количество добавляемых элементов: ");
    int[,] addArray = new int[tDimArr.GetLength(0) + n, tDimArr.GetLength(1)];     // генерация нового массива

    for (int i = 0; i < addArray.GetLength(0); i++)     // заполнение массива новыми строками
    {
        for (int j = 0; j < addArray.GetLength(1); j++)
        {
            if (i < n)
            {
                addArray[i, j] = rnd.Next(0, 100);      // рандом
            }
            else
            {
                addArray[i, j] = tDimArr[k, j];     // заполнение прошлых строк
            }
        }
        if (i >= n)
            k++;
    }
    return addArray;            // возвращение измененного массива
}
static int[][] DeleteLineMass(ref int[][] jagArr, int number)       // удаление строк из рваного массива
{
    int[][] newArr = new int[jagArr.Length - 1][];      // создание нового массива

    int k = 0;
    for (int i = 0; i < jagArr.Length; i++)
    {
        if ((i + 1) != number)        // проверка, строка, которую нужно удалить или нет
        {
            newArr[k] = jagArr[i];      // заполнение массива
            k++;
        }
    }
    return newArr;      // возвращает изменённый массив
}
static int GetInteger()     // проверка числа
{
    string input; int number;       // 1 - ввод строки. 2 - полученное число
    do
    {
        input = ReadLine();
    }
    while (!int.TryParse(input, out number));       // пока условие не выполнено(введено целое число), продолжится ввод числа
    return number;      // возвращает число
}