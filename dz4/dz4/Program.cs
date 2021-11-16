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
            while (!(N>0))
            {
                Console.Write("ОШИБКАШИБКАОШИБКА\nВведите верное значение\n");                   
                    N = int.Parse(Console.ReadLine());                
            }           
            double[] Array = new double[(int)N];

            
            //Заполняем массив
            for (int i = 0; i < N; i++)
            {
                Array[i] = (double)(rand.NextDouble() * rand.Next(-10, 10));
                Array[i]= Math.Round(Array[i], 2);
                Console.Write("{0} ", Array[i]);
            }
            
            //Вычисляем сумму элементов массива с нечетными номерами
            double count = 0;
            for (int i = 0; i < N; ++i)
            {
                 if (Array[i] % 2 != 0)
                    Array[i] = Math.Round(Array[i], 2);
                count += Array[i];                    
            }
            Console.Write($"\nCуммa элементов массива с нечетными номерами : {Math.Round(count, 2)}");

            //Вычисляем сумму элементов расположенных между первым и последним отрицательными элементами

            double SM = Array.SkipWhile(r => r >= 0).Skip(1).Reverse().SkipWhile(r => r >= 0).Skip(1).Sum();
            for (int i = 0; i < N; ++i)
            {
                Array[i] = Math.Round(Array[i], 2);
            }
            Console.WriteLine($"\nСумма элементов между отрицательными элементами = {Math.Round(SM, 2)}");


            //Убираем элементы с модулем менее единицы
            for (int i = 0; i < N; i++)
            {
                if (Math.Abs(Array[i]) < 1)
                {
                    Array[i] = 0;
                }

                Array[i] = Math.Round(Array[i], 2);
            }

            //Сжимаем массив и заполняем освобожденные элементы нулями
            var Array2 = Array.Where(n => !(Math.Abs(n) <= 1));
            Array2 = Array2.Concat(new double[Array.Length - Array2.Count()]).ToArray();
            Console.WriteLine("Cжатый массив:");
            foreach (double i in Array2) Console.Write("{0} ", i);
            Console.Read();
        }

    }
}