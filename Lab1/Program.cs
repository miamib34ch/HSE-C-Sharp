using static System.Console;
using static System.Math;

bool notComplet = true;

do
{
    Clear();
    Write("Выберите задание (1,2,3): ");
    switch (ReadLine())
    {
        case "1":
            Write("Введите значение m: "); //ввод m
            float m = float.Parse(ReadLine()); //перевод строки в число
            Write("Введите значение n: "); //ввод n
            float n = float.Parse(ReadLine()); //перевод строки в число
            Write("Введите значение x: "); //ввод x
            double x = double.Parse(ReadLine()); //перевод строки в число
            float a = n, b = m, y = n, u = m, r1 = --m - n++; //присвоение a,b,u,y значений n и m, тк дальше из-за операции их значения меняются, а нам нужны для дальнейшего решения оригинальные значения
            bool r2 = b * b < a++, r3 = y-- > ++u; //присвоение результатов
            WriteLine("");
            WriteLine($"m = {m}, n = {n}, --m-n++ = {r1}"); //вывод результатов
            WriteLine($"m = {b}, n = {a}, m*m<n++ = {r2}");
            WriteLine($"m = {u}, n = {y}, n-->++m = {r3}");
            WriteLine("");
            double r4 = Tan(x) - Pow(5 - x, 4); //присвоение результата
            WriteLine($"x = {x}, tg(x)-(5-x)^4 = {r4}"); //вывод результата
            ReadLine();
            break;
        case "2":
            Write("Введите x: "); //ввод х
            float x1 = float.Parse(ReadLine()); //перевод строки в число
            Write("Введите y: "); //ввод y
            float y1 = float.Parse(ReadLine()); //перевод строки в число
            bool u1 = (Pow(x1, 2) + Pow(y1, 2) <= 1) & (x1 >= 0); //присвоение u математической модели
            WriteLine($"Ответ: {u1}"); //вывод ответа 
            ReadLine();
            break;
        case "3":
            double a2 = 100, b2 = 0.001, r12 = (Pow(a2 - b2, 3) - (Pow(a2, 3) - 3 * Pow(a2, 2) * b2)) / (3 * a2 * Pow(b2, 2) - Pow(b2, 3)); //ввод переменных 
            float r22 = ((float)Pow(a2 - b2, 3) - ((float)Pow(a2, 3) - 3 * (float)Pow(a2, 2) * (float)b2)) / (3 * (float)a2 * (float)Pow(b2, 2) - (float)Pow(b2, 3));
            WriteLine($"double: a = 100, b = 0,001, ((a-b)^3-(a^3-3a^2 * b))/(3ab^2 - b^3) = {r12}"); //вывод ответа
            WriteLine($"float: a = 100, b = 0,001, ((a-b)^3-(a^3-3a^2 * b))/(3ab^2 - b^3) = {r22}");
            ReadLine();
            break;
        default:
            notComplet = false;
            break;
    }
} while (notComplet);