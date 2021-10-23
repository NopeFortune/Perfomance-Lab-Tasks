using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace PLtask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к файлу окружности: ");
            string circlepath = Console.ReadLine();

            Console.Write("Введите путь к файлу точек: ");
            string pointspath = Console.ReadLine();
            Console.WriteLine();

            Points(circlepath, pointspath);

            Console.ReadLine();
        }

        #region Точка на окружности
        public static void Points(string circlepath, string pointspath)
        {
            Circle circle = new Circle();

            // Считываем данные из файла и записываем их в переменные класса Circle.
            using (StreamReader sr = new StreamReader(circlepath))
            {
                string text = File.ReadAllText(circlepath).Trim();

                circle.X = text[0] - '0';
                circle.Y = text[2] - '0';
                circle.Radius = text[text.Length - 1] - '0';
            }

            // Работа с файлом, содержащим координаты точек.
            using (StreamReader sr = new StreamReader(pointspath))
            {
                int length = File.ReadAllLines(pointspath).Length; // Вычисляем кол-во строк.
                Point[] points = new Point[length]; // Создаём массив точек, имеющий длину, равной количеству строк в файлею.

                string text = ""; // вспомогательная переменная.

                for (int i = 0; i < points.Length; i++)
                {
                    text = sr.ReadLine().Replace('.', ',').Trim(); // в вспомогательную переменную считываем данные со строки, заменяем запятые на точки, в случае необходимости.

                    // далее парсируем строку в координаты точек X,Y.
                    // Для 'X' берем подстроку от начала до пробела.
                    // Для 'Y' берем подстроку от следующего символа после пробела и до конца строки.

                    points[i] = new Point();
                    points[i].X = double.Parse(text.Substring(0, text.IndexOf(' ')));
                    points[i].Y = double.Parse(text.Substring(text.IndexOf(' ') + 1, text.Length - text.IndexOf(' ') - 1));

                    double formularesult = Math.Pow(points[i].X - circle.X, 2) + Math.Pow(points[i].Y - circle.Y, 2); //Мат формула (x-x0)^2 + (y-y0)^2 <=R^2

                    if (formularesult > Math.Pow(circle.Radius, 2))
                    {
                        Console.WriteLine("2 - точка снаружи");
                    }
                    else if (formularesult == Math.Pow(circle.Radius, 2))
                    {
                        Console.WriteLine("0 - точка лежит на окружности");
                    }
                    else
                    {
                        Console.WriteLine("1 - точка внутри");
                    }
                }
            }
            #endregion
        }
    }

    public class Circle
    {
        private double x;
        private double y;
        private double radius;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                radius = value;
            }
        }
    }

    public class Point
    {
        private double x;
        private double y;

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }
}
