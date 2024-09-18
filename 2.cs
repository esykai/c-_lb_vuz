// 2.1

using System;

class Program
{
    static void Main()
    {
        try
        {
            Console.Write("Введите число в десятичной системе: ");
            int number = int.Parse(Console.ReadLine());
            string binary = Convert.ToString(number, 2);
            Console.WriteLine("Число {0} в двоичной системе: {1}", number, binary);
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введено некорректное число.");
        }
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка: Введенное число слишком большое.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: {0}", ex.Message);
        }
    }
}

// 2.2
using System;

class Program
{
    static void Main()
    {
        try
        {
            double a = GetCoefficient("Введите коэффициент a (a != 0): ");
            while (a == 0)
            {
                Console.WriteLine("Ошибка: коэффициент 'a' не может быть равен 0. Повторите ввод.");
                a = GetCoefficient("Введите коэффициент a (a != 0): ");
            }

            double b = GetCoefficient("Введите коэффициент b: ");
            double c = GetCoefficient("Введите коэффициент c: ");

            string equation = FormatEquation(a, b, c);
            Console.WriteLine("Уравнение: " + equation);

            double discriminant = b * b - 4 * a * c;
            Console.WriteLine("Дискриминант: " + discriminant);

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("Корни уравнения: x1 = " + x1 + ", x2 = " + x2);

                Console.WriteLine("Проверка: a * x1^2 + b * x1 + c = " + (a * x1 * x1 + b * x1 + c));
                Console.WriteLine("Проверка: a * x2^2 + b * x2 + c = " + (a * x2 * x2 + b * x2 + c));
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Корень уравнения: x = " + x);

                Console.WriteLine("Проверка: a * x^2 + b * x + c = " + (a * x * x + b * x + c));
            }
            else
            {
                Console.WriteLine("Уравнение не имеет действительных корней.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
    }

    static double GetCoefficient(string message)
    {
        double coefficient;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            try
            {
                coefficient = double.Parse(input);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: Введено некорректное значение. Попробуйте снова.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Ошибка: Введено слишком большое или маленькое число. Попробуйте снова.");
            }
        }
        return coefficient;
    }

    static string FormatEquation(double a, double b, double c)
    {
        string equation = String.Format("{0}x^2 ", a);

        if (b < 0)
        {
            equation += String.Format("- {0}x ", Math.Abs(b));
        }
        else if (b > 0)
        {
            equation += String.Format("+ {0}x ", b);
        }

        if (c < 0)
        {
            equation += String.Format("- {0} = 0", Math.Abs(c));
        }
        else if (c > 0)
        {
            equation += String.Format("+ {0} = 0", c);
        }
        else
        {
            equation += "= 0";
        }

        return equation;
    }
}
