using System;
using System.Linq;
using System.Text;

namespace Mass
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            Console.Write("Введите размер массива N = ");
            int N = int.Parse(Console.ReadLine());
            int[] Array = new int[N];

            //Заполняем массив
            for (int i = 0; i < N; i++)
            {
                Array[i] = rand.Next(-10, 10);
                Console.Write("{0} ", Array[i]);
            }
            //Вычисляем сумму элементов массива с нечетными номерами
            int count = 0;
            for (int i = 0; i < N; ++i)
            {
                if (Array[i] % 2 != 0)
                    count += Array[i];
            }
            Console.Write("\n\nCуммa элементов массива с нечетными номерами : {0}", count);

            //Вычисляем сумму элементов расположенных между первым и последним отрицательными элементами

            int SM = Array.SkipWhile(r => r >= 0).Skip(1).Reverse().SkipWhile(r => r >= 0).Skip(1).Sum();
            Console.WriteLine("\nСумма элементов между отрицательными элементами = {0}", SM.ToString());

            //Убираем элементы с модулем менее единицы
            for (int i = 0; i < N; i++)
            {
                if (Math.Abs(Array[i]) < 1) Array[i] = 0;
            }

            //Сжимаем массив и заполняем освобожденные элементы нулями
            var Array2 = Array.Where(n => !(Math.Abs(n) <= 1));
            Array2 = Array2.Concat(new int[Array.Length - Array2.Count()]).ToArray();
            Console.WriteLine("Cжатый массив:");
            foreach (int i in Array2) Console.Write("{0} ", i);
            Console.Read();
        }

    }
}