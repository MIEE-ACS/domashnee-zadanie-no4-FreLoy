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
                for (int j = 0; j < N; j++)
                {
                    if (mat[i, j] > 0)
                    {
                        if (!RowTotal[i].Equals(0))
                            RowTotal[i] *= mat[i, j];
                        else RowTotal[i] = mat[i, j];

                    }
                }

            }
            for (int i = 0; i < N; i++)
                Console.WriteLine("Строка  {0} матрицы имеет произведение положительных элементов равное: {1}", i + 1, RowTotal[i]);
            Console.ReadKey(true);

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


