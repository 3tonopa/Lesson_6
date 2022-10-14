using System;   //Д/З №6 Стрелков Максим.
using System.IO;


//создание делегата
public delegate double Func(double x);
class Task2
    {
    public static void Menu_1()
    {
        Console.Clear();
        Console.WriteLine(@"Нахождение минимума функции.
                                                        ");
        Console.WriteLine("Введите нижнюю границу диапазона>>>");
        double a = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите верхнюю границу диапазона>>>");
        double b = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите шаг>>>");
        double h = double.Parse(Console.ReadLine());
        Menu_2(a, b, h);
    }
    
    static void Menu_2(double a, double b, double h)
    {
        Console.Clear();
        Console.WriteLine("Выберите функцию:");
        Console.WriteLine(" x^2                    [1]");
        Console.WriteLine(" x^3                    [2]");
        Console.WriteLine(" Sin x                  [3]");
        Console.WriteLine(" x^2-50(x)+10           [4]");
        Console.WriteLine("Возврат в главное меню  [5]");
        Console.WriteLine("Выход                   [0]");
        
        while (true)
        {
            int num = int.Parse(Console.ReadLine());
            
            switch (num)

                {
                case 0:

                    break;

                case 1:
                                        
                    Start(Func_00, a, b, h);
                    Console.WriteLine("Нажмите любую клавишу чтобы вернуться в меню.");
                    Console.ReadKey();
                    Menu_2(a, b, h);
                    break;

                case 2:

                    Start(Func_01, a, b, h);
                    Console.WriteLine("Нажмите любую клавишу чтобы вернуться в меню.");
                    Console.ReadKey();
                    Menu_2(a, b, h);
                    break;

                case 3:

                    Start(Func_02, a, b, h);
                    Console.WriteLine("Нажмите любую клавишу чтобы вернуться в меню.");
                    Console.ReadKey();
                    Menu_2(a, b, h);
                    break;
                   
                case 4:
                    
                    Start(Func_03, a, b, h);
                    Console.WriteLine("Нажмите любую клавишу чтобы вернуться в меню.");
                    Console.ReadKey();
                    Menu_2(a, b, h);
                    break;

                case 5:

                    Menu.MainMenu();
                    break;

            }
            if (num > 5 && true)
            {
                Console.WriteLine("Вы ввели неправильный номер, нажмите Enter и повторите попытку.");
                Console.ReadKey();
                Menu_2(a, b, h);
            }
            if (false)
            {
            }
            break;
        }
    }
    static void Start(Func f, double a, double b, double h)
    {
        SaveFunc(f, "data.bin", a, b, h);
        Console.WriteLine($"Результат: {Load("data.bin")} ");
    }
    static void SaveFunc(Func F, string fileName, double a, double b, double h)
    {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
    }
        public static double Load(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
    //методы функций
    public static double Func_00(double x)
    {
        return x * x;
    }
    public static double Func_01(double x)
    {
        return x * x * x;
    }
    public static double Func_02(double x)
    {
        return Math.Sin(x);
    }
    public static double Func_03(double x)
    {
        return x * x - 50 * x + 10;
    }
}

