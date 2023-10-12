using System;

namespace ConsoleApp1
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; //Ставим результату по умолчанию значение "не число"
                                        //Смотрим действие и выполняем
            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                default: break;
            }
            return result;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            //Выводим слова
            Console.WriteLine("Консольный калькулятор на C#\n");
            do
            {
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;
                Console.Write("Введите первый аргумент и нажмите Enter: ");
                numInput1 = Console.ReadLine();
                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Это неверный ввод. Пожалуйста, введите допустимое число: ");
                    numInput1 = Console.ReadLine();
                }
                Console.WriteLine("Введите действие из списка:");
                Console.WriteLine("\t+ - Сложить");
                Console.WriteLine("\t- - Вычесть");
                Console.WriteLine("\t* - Умножить");
                Console.WriteLine("\t/ - Разделить");
                Console.Write("Ваш выбор? ");
                string op = Console.ReadLine().Substring(0, 1);
                string ops = "+-*/";
                while (ops.IndexOf(op) == -1)
                {
                    Console.Write("Это неверный ввод. Пожалуйста, выберите допустимое действие: ");
                    op = Console.ReadLine();
                    if (op.Length > 1) op = op.Substring(0, 1);
                }
                Console.Write("Введите второй аргумент и нажмите Enter: ");
                numInput2 = Console.ReadLine();
                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Это неверный ввод. Пожалуйста, введите допустимое число: ");
                    numInput2 = Console.ReadLine();
                }
                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result) | double.IsInfinity(result))
                    {
                        Console.WriteLine("Операция не может быть выполнена\n");
                    }
                    else Console.WriteLine("Ваш результат: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Ошибка при использовании Math.\nДетали: " + e.Message);
                }
                Console.Write("Нажмите 'n' и Enter для выхода или любую клавишу и Enter для продолжения: ");
                op = Console.ReadLine();
                if (op.Length > 1) op = op.Substring(0, 1);
                if (op == "n") endApp = true;
                Console.WriteLine("\n");
            } while (!endApp);
            return;
        }
    }
}
