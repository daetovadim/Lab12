using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\tРабота с окружностью.\n");

            Console.Write("Введите радиус окружности: ");
            try
            {
                Circle.radius = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Длина окружности с заданным радиусом = {0:.00}", Circle.Length());
                Console.WriteLine("Площадь окружности с заданным радиусом = {0:.00}", Circle.Area());

                Console.WriteLine("\n\tПроверка принадлежности точки к окружности.\n");

                Console.Write("Введите координату х точки: ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите координату у точки: ");
                double y = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите координату х центра окружности: ");
                double x0 = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите координату у центра окружности: ");
                double y0 = Convert.ToDouble(Console.ReadLine());

                bool belong = Circle.Belong(x, y, x0, y0);
                if (belong == true)
                    Console.WriteLine("\nТочка принадлежит окружности с заданными параметрами.");
                else
                    Console.WriteLine("\nТочка не принадлежит окружности с заданными параметрами.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка! Введённое значение не является числом.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nОшибка! Значение радиуса не может быть отрицательным.");
            }

            Console.ReadKey();
        }

        public static class Circle
        {
            public static double radius;

            public static double Length()
            {
                if (radius >= 0)
                {
                    double length = 2 * Math.PI * radius;
                    return length;
                }
                else
                    throw new ArgumentOutOfRangeException("Radius", "Значение радиуса не может быть отрицательным");
            }

            public static double Area()
            {
                if (radius >= 0)
                {
                    double area = Math.PI * Math.Pow(radius, 2);
                    return area;
                }
                else
                    throw new ArgumentOutOfRangeException("Radius", "Значение радиуса не может быть отрицательным");
            }

            public static bool Belong(double x, double y, double x0 = 0, double y0 = 0)
            {
                double distance = Math.Sqrt(Math.Pow(x - x0, 2) + Math.Pow(y - y0, 2));
                if (distance <= radius)
                    return true;
                else
                    return false;
            }
        }
    }
}
