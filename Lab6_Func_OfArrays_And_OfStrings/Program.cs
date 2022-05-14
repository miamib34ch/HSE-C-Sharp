using System.Globalization;
using static System.Console;

int userChoise = -1; // инициализация переменной, отвечающей за выбор в меню
string predloj = ""; // инициализация строки
while (userChoise != 0) // цикл, чтобы программа не закончилась, пока этого не захочит пользователь
{
    Clear();       // очищение консоли
    WriteLine("Выберите необходимое действие:"); // вывод меню
    WriteLine("1 - Задание 1.");
    WriteLine("2 - Задание 2.");
    WriteLine("0 - Завершить работу программы.");
    WriteLine("Любое иное целое число - очистить экран.");
    WriteLine();
    userChoise = GetInteger();  // ввод с проверками пользователем пункта меню

    switch (userChoise)         // выбор встоотвествие с выбром пользователя
    {
        case 1: // задание 1
            Clear();
            int[][] jagArr = CreateJagArr(out int jagSize); // создание рванного целочисленного массива 
            Clear();
            jagArr = FillJagArr(ref jagArr); // присвоение значений в массиве
            Clear();
            PrintMass(ref jagArr);     // вывод массива
            Write("Для продолжения нажмите любую клавишу."); ReadLine();
            jagArr = SortArr(ref jagArr); // сортировка массива в соответсвии с заданием 
            Clear();
            PrintMass(ref jagArr);     // вывод массива
            Write("Для продолжения нажмите любую клавишу."); ReadLine(); // ввод для задержки на экране 
            break;
        case 2: // задание 2
            Clear();
            predloj = CreateString(ref predloj); // создание строки
            if (predloj == "Пустая строка!") // конец задания если ввели пустую строку 
            {
                WriteLine("Пустая строка!");
                WriteLine();
                Write("Для продолжения нажмите любую клавишу."); ReadLine();
                break;
            }
            predloj = ChangePlace(ref predloj); // изменение места слов в соответсвии с заданием 
            WriteLine($"Изменённое предложение: {predloj}"); // вывод строки
            WriteLine();
            Write("Для продолжения нажмите любую клавишу."); ReadLine(); // ввод для задержки на экране 
            break;
        default:    // Действие по умолчанию
            Clear();        // очистить консоль
            break;
    }
    WriteLine();
}

static int ArrSize(string msg)      // чтобы задать размер массива и числа, которые не должны быть <= 0
{
    int size = 0; //инициализация локальной переменной размер
    Write(msg); // вывод поступившей строки
    while (size <= 0) // входные данные 
    {
        size = GetInteger();        // считывает число
        if (size <= 0)
        {
            Write("Введите целое число больше нуля: ");
        }
    }
    return size;        // возвращает число
}
static int[][] CreateJagArr(out int jagSize)        // создаёт рваный массив
{
    jagSize = ArrSize("Введите количество строк массива: ");
    int[][] arr = new int[jagSize][]; // инициализация локального рванного массива
    Random rnd = new Random(); // инициализация ДСЧ
    for (int i = 0; i < jagSize; i++)
    {
        arr[i] = new int[rnd.Next(1, 100)]; // присвает случайное значение колву столбцов
    }
    return arr;     // возвращает рваный массив
}
static int[][] FillJagArr(ref int[][] jagArr)       // заполняет рваный массив
{
    int check = 1; // инициализация переменной для выбора

    WriteLine("1 - Заполнить массив с клавиатуры.");     // меню
    WriteLine("2 - Заполнить массив случайными числами.");
    WriteLine();
    check = GetInteger(); // ввод значения пользователем
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
static void PrintMass(ref int[][] jagArr)           // вывести массив
{
    WriteLine("Ваш массив:");
    for (int i = 0; i < jagArr.Length; i++)
    {
        for (int j = 0; j < jagArr[i].Length; j++)
            Write(jagArr[i][j].ToString() + " ");
        WriteLine();
    }
}
static int GetInteger()     // проверка числа
{
    string input; int number;       // 1 - ввод строки, 2 - полученное число
    do
    {
        input = ReadLine();
    }
    while (!int.TryParse(input, out number));       // пока условие не выполнено(введено целое число), продолжится ввод числа
    return number;      // возвращает число
}
static int[][] SortArr(ref int[][] jagArr)
{
    for (int i = 0; i < jagArr.Length; i++) //сортировка столбцов внутри строк рванного массива простым выбором
    {
        for (int j = 0; j < jagArr[i].Length; j++)
        {
            int tmp = jagArr[i][j]; // берётся первый элемент, и сравнивается с остальными 
            int nomer = j;
            for (int k = 0 + j; k < jagArr[i].Length; k++)
            {
                if (jagArr[i][k] < tmp)
                {
                    tmp = jagArr[i][k];
                    nomer = k;
                }
            }
            jagArr[i][nomer] = jagArr[i][j];
            jagArr[i][j] = tmp;
        }
    }
    for (int j = 0; j < jagArr.Length; j++)
    {
        int count = 0;
        for (int i = 0; i < jagArr[j].Length; i++) //сортировка строк рванного массива по возрастанию
        {
            count++;
        }
        int[] tmpArr = new int[count];
        tmpArr = jagArr[j];
        for (int k = 0; k < jagArr.Length; k++) // подобный прицип, только места числа строки массива 
        {
            if (jagArr[k].Length > tmpArr.Length)
            {
                int count2 = 0;
                for (int i = 0; i < jagArr[k].Length; i++)
                {
                    count2++;
                }
                int[] tmpArr2 = new int[count2];
                tmpArr2 = jagArr[k];
                jagArr[k] = new int[count];
                jagArr[k] = tmpArr;
                jagArr[j] = new int[count2];
                jagArr[j] = tmpArr2;
                break;
            }
        }
    }
    return jagArr;
}       //сортировка массива
static string CreateString(ref string predloj)
{
    bool check = false;
    Write("Введите ваше предложение: ");
    predloj = ReadLine(); // ввод
    check = CheckString(ref predloj); //проверка на пустоту
    if (check == true) // вывод ответа
    {
        return predloj;
    }
    else
    {
        predloj = "Пустая строка!";
        return predloj;
    }
}  // создание строки
static bool CheckString(ref string predloj)
{
    bool check = false;
    string[] proverka = predloj.Split();
    int count = 0;
    for (int i = 0; i < proverka.Length; i++) // проверяет каждый элемент строки на пустой знак
        if (proverka[i] == "") count++;
    if (count != proverka.Length) check = true;
    return check;
}      // проверка строки на пустоту 
static string ChangePlace(ref string predloj)
{
    string[] prArr = predloj.Split();
    string tmp = "";
    if (!(prArr[prArr.Length - 1] == "!" || prArr[prArr.Length - 1] == "?" || prArr[prArr.Length - 1] == ".")) // проверка на стоит ли знак в конце вместе со словом или через пробел 
    {
        prArr = CheckZnak(ref prArr); // случай если слитно, сохранение знака на месте
        tmp = prArr[0].ToLower(); // смена регистра для последнего слова
        TextInfo Last = CultureInfo.CurrentCulture.TextInfo; // переменная с текстовой информацией, нужна для изменения регистра первой буквы
        prArr[0] = Last.ToTitleCase(prArr[prArr.Length - 1]); // смена регистра первой буквы первого слова
        prArr[prArr.Length - 1] = tmp;
    }
    else                                             // случай если знак стоит через пробел
    {
        tmp = prArr[0].ToLower();
        TextInfo Last = CultureInfo.CurrentCulture.TextInfo;
        prArr[0] = Last.ToTitleCase(prArr[prArr.Length - 2]);
        prArr[prArr.Length - 2] = tmp;
    }
    string[] tmpArr = new string[prArr.Length * 2]; // возвращение пробелов в строку через увелечение массива и присвоение прбелов каждому второму 
    int count = 0;
    for (int i = 0; i < tmpArr.Length; i++)
    {
        if (i % 2 == 0)
        {
            tmpArr[i] = prArr[i - count];
        }
        else
        {
            tmpArr[i] = " ";
            count++;
        }
    }
    predloj = string.Concat(tmpArr); // сбор строки из массива
    return predloj;
}   // смена мест у первого и последнего слова
static string[] CheckZnak(ref string[] prArr)
{
    char[] slovo = new char[prArr[0].ToString().Length]; // инициализация символьного массива для удаления изменения знака 
    char[] slovoL = new char[prArr[prArr.Length - 1].ToString().Length]; // инициализация символьного массива
    char zamena = ' ';
    char zamena2 = ' ';
    for (int i = 0; i < slovo.Length; i++)
        slovo[i] = prArr[0][i];
    for (int j = 0; j < slovoL.Length; j++)
        slovoL[j] = prArr[prArr.Length - 1][j];
    if (slovo[slovo.Length - 1] == '!' || slovo[slovo.Length - 1] == '?' || slovo[slovo.Length - 1] == ',' || slovo[slovo.Length - 1] == '.' || slovo[slovo.Length - 1] == ':' || slovo[slovo.Length - 1] == ';')
    {
        zamena = slovo[slovo.Length - 1]; // сохранение знака 
    }
    if (slovoL[slovoL.Length - 1] == '!' || slovoL[slovoL.Length - 1] == '?' || slovoL[slovoL.Length - 1] == ',' || slovoL[slovoL.Length - 1] == '.' || slovoL[slovoL.Length - 1] == ':' || slovoL[slovoL.Length - 1] == ';')
    {
        zamena2 = slovoL[slovoL.Length - 1]; // сохранение знака 
    }
    if ((slovo[slovo.Length - 1] == '!' | slovo[slovo.Length - 1] == '?' | slovo[slovo.Length - 1] == ',' | slovo[slovo.Length - 1] == '.' | slovo[slovo.Length - 1] == ':' | slovo[slovo.Length - 1] == ';') || (slovoL[slovoL.Length - 1] == '!' | slovoL[slovoL.Length - 1] == '?' | slovoL[slovoL.Length - 1] == ',' | slovoL[slovoL.Length - 1] == '.' | slovoL[slovoL.Length - 1] == ':' | slovoL[slovoL.Length - 1] == ';'))
    {
        slovo[slovo.Length - 1] = zamena2; // обмен знаками
        slovoL[slovoL.Length - 1] = zamena;
        prArr[0] = string.Concat(slovo);
        prArr[prArr.Length - 1] = string.Concat(slovoL); //сбор строки из массива
    }
    return prArr;
}    // проверка знака у первого и последнего слова, сохранение их на месте