using System;    //Д/З №6 Стрелков Максим.

public class Menu
{
    public static void Main(string[] args)
    {
        MainMenu();
    }
    public static void MainMenu()
    {
        Console.Clear();

        while (true)
        {
            Console.WriteLine("[1] Задача №1");
            Console.WriteLine("[2] Задача №2");
            Console.WriteLine("[3] Задача №3");
            Console.WriteLine("[0] Выход");
            Console.WriteLine();
            Console.Write($"Выбор: ");
            int num = int.Parse(Console.ReadLine());

            switch (num)
            {
                case 0:
                    
                    break;

                case 1:
                    Task1.Start();
                    break;

                case 2:
                    Task2.Menu_1();
                    break;

                case 3:
                    Task3.Start();
                    break;
            }
            if (num > 3 && true)
            {
                Console.WriteLine("Вы ввели неправильный номер, нажмите Enter и повторите попытку.");
                Console.ReadKey();
                MainMenu();
            }
            if (false)
            {
            }
            break;
        }
        
    }
}