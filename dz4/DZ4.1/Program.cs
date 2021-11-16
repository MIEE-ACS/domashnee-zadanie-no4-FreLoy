using System;

namespace DZ4._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat;

            Console.WriteLine("Введите размер матрицы: N =");
            int N = int.Parse(Console.ReadLine());
            while (!(N > 0))
            {
                Console.Write("ОШИБКАШИБКАОШИБКА\nВведите верное значение\n");
                    N = int.Parse(Console.ReadLine());                
            }            
            mat = new int[N, N];
            Random rand = new Random();

            //Заполняем матрицу
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    mat[i, j] = rand.Next(-10, 10);
                }
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write("{0}\t", mat[i, j]);
                }
                Console.WriteLine();
            }

            //Перемножаем только положительные значения в предобъявленную переменную
            int[] RowTotal = new int[N];
            for (int i = 0; i < N; i++)
            {
                long p = 1L;
                int j;
                for (j = 0; j < N; j++)
                {
                    if (mat[i, j] < 0) break;
                    p *= mat[i, j];
                }
                if (j == N)
                {
                    Console.WriteLine("Произведение строки {0}: {1}", i, p);
                }
                else
                {
                    Console.WriteLine("Строка {0} имеет отрицательное число!", i);
                }
            }

            int[] SUS = new int[2*N-1];
            int chetchik = 0;
            for (int i = 0; i < N; i++) for(int j = 0; j < N; j++)
            {
                if (i == j)
                {
                        SUS[0] += mat[i, j];
                }
                else if( j<=i-1)
                    {
                        SUS[i - j ] += mat[i, j];
                    }
                else if (i<=j-1)
                    {
                        SUS[j - i + N - 1] += mat[i, j];
                    }
            }
            int max = SUS[0];
            for(int i = 0; i < 2*N-1; i++)
            {
                if (SUS[i] > max) max = SUS[i];
            }
            Console.WriteLine($"Максимум среди сумм элементов диагоналей, параллельных главной диагонали матрицы:{max}");
        }
    }
}


