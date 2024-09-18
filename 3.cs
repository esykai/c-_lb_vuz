// 3.1

using System;

class Triangle
{
    private double a, b, c;
    private bool d;

    public Triangle(double sideA, double sideB, double sideC)
    {
        a = sideA;
        b = sideB;
        c = sideC;
        d = (a + b > c) && (a + c > b) && (b + c > a);
    }

    public string Type
    {
        get
        {
            if (!d)
                return "Треугольник не существует";

            if (a == b && b == c)
                return "Равносторонний треугольник";
            else if (a == b || b == c || a == c)
                return "Равнобедренный треугольник";
            else if (IsRightTriangle())
                return "Прямоугольный треугольник";
            else
                return "Треугольник общего вида";
        }
    }

    private bool IsRightTriangle()
    {
        return (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2)) ||
               (Math.Pow(a, 2) + Math.Pow(c, 2) == Math.Pow(b, 2)) ||
               (Math.Pow(b, 2) + Math.Pow(c, 2) == Math.Pow(a, 2));
    }

    public static void Main()
    {
        Triangle triangle = new Triangle(3, 4, 5);
        Console.WriteLine(triangle.Type);
    }
}

// 3.2
using System;

class QuadraticEquation
{
    private double a, b, c;
    public int er { get; private set; }
    private string err;

    public QuadraticEquation(double coefA, double coefB, double coefC)
    {
        a = coefA;
        b = coefB;
        c = coefC;

        if (a == 0)
        {
            er = 3; 
            err = "Неквадратное уравнение";
        }
        else
        {
            CalculateRoots();
        }
    }

    private double D()
    {
        return (b * b) - (4 * a * c);
    }

    private void CalculateRoots()
    {
        double discriminant = D();

        if (discriminant < 0)
        {
            er = 0;
            err = "Действительных корней нет";
        }
        else if (discriminant == 0)
        {
            er = 1;
        }
        else
        {
            er = 2;
        }
    }

    public string X1
    {
        get
        {
            if (er == 3 || er == 0)
                return err;
            else
                return ((-b + Math.Sqrt(D())) / (2 * a)).ToString();
        }
    }

    public string X2
    {
        get
        {
            if (er == 3 || er == 0)
                return err;
            else if (er == 1)
                return "Второй корень не существует";
            else
                return ((-b - Math.Sqrt(D())) / (2 * a)).ToString();
        }
    }

    public void Proverka()
    {
        if (er == 1 || er == 2)
        {
            double x1 = Convert.ToDouble(X1);
            double x2 = er == 2 ? Convert.ToDouble(X2) : 0;
            Console.WriteLine($"Проверка корней: ax1^2 + bx1 + c = {a * Math.Pow(x1, 2) + b * x1 + c}");
            if (er == 2)
            {
                Console.WriteLine($"Проверка второго корня: ax2^2 + bx2 + c = {a * Math.Pow(x2, 2) + b * x2 + c}");
            }
        }
        else
        {
            Console.WriteLine(err);
        }
    }

    public static void Main()
    {
        QuadraticEquation eq = new QuadraticEquation(1, -3, 2);
        Console.WriteLine("Первый корень: " + eq.X1);
        Console.WriteLine("Второй корень: " + eq.X2);
        eq.Proverka();
    }
}
