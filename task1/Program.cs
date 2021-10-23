using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLtask1
{
    #region Описание задания

    /*
    Круговой массив - массив из элементов, в котором по достижению конца массива следующим
    элементом будет снова первый. Mассив задается числом n, то есть представляет собой числа от 1 до n.
    Пример кругового массива для n=3:
    1231231.

    Напишите программу, которая выводит путь, по которому, двигаясь интервалом длины m по
    заданному массиву, концом будет являться первый элемент.
    */

    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите N: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("\nВведите M: ");
            int m = int.Parse(Console.ReadLine());

            CircularArray(n, m);
            Console.ReadKey();
        }

        #region Круговой массив
        public static void CircularArray(int n, int m)
        {
            List<int> list = Enumerable.Range(1, n).ToList(); // Генерируем коллекцию, которая содержит последовательность чисел.
            string result = "";
            List<int> helper = new List<int>(); // Создаём вспомогательную коллекцию.

            if (m > n || m <= 0) // Проверка на входящие данные.
            {
                throw new ArgumentOutOfRangeException();
            }
            else
            {
                while (list.IndexOf(1) != m - 1) // проверяем до тех пор, пока единица не будет под индексом m-1(если она под индексом m-1 - то это последний интервал, m-1 т.к индексация в коллекциях начинается с 0).
                {
                    result += list[0]; // Записываем первое число интервала.

                    helper = list.Take(m - 1).ToList(); // Используем вспомогательную коллекцию, чтобы взять первые числа последовательности.
                    list.AddRange(helper); // Добавляем числа из вспомогательной коллекции в конец.

                    list.RemoveRange(0, m - 1); // Удаляем эти же числа из начала коллекции.
                }
                result += list[0]; // Дозаписываем последний результат, тк мы вышли из цикла.
                Console.WriteLine($"\n{result}");
            }
        }
        #endregion
    }
}
