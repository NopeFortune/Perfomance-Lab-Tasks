using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PLtask4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь: ");

            MinSteps(Console.ReadLine());
            Console.ReadLine();
        }

        #region минимальное количество ходов, требуемых для приведения всех элементов к одному числу
        public static void MinSteps(string path)
        {
            using (StreamReader sr = new StreamReader(path)) // считываем файл
            {
                int length = File.ReadAllLines(path).Length; // получаем кол-во строк файла
                int[] array = new int[length];  // создаём массив, в которые будем запиысывать значения, считанные из файла

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = int.Parse(sr.ReadLine().Trim()); // считываем строчку и преобразуем ее в число.
                }

                double average = Math.Round(array.Average());  // ищем среднее значение всех чисел (находим число, к которому надо привести).
                double steps = 0; // кол-во ходов.
                
                // далее берем разницу между числом и средним значением - это кол-во ходов, которое нужно совершить чтобы привести одно число.
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == average)
                    {
                        continue;
                    }
                    else if (array[i] > average)
                    {
                        steps += array[i] - average;
                    }
                    else
                    {
                        steps += average - array[i];
                    }
                }
                Console.WriteLine(steps);
            }
        }
        #endregion
    }
}
