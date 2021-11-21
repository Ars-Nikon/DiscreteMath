using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2
{
    static internal class FuzzyRelationships
    {
        static public void Write(double[,] A)
        {
            if (A == null)
            {
                throw new ArgumentNullException();
            }

            var table = new ConsoleTable();
            for (int i = 0; i < A.GetLength(0); i++)
            {
                var line = new string[A.GetLength(1)];
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    line[j] = Math.Round(A[i, j], 1).ToString();
                }
                if (i == 0)
                {
                    table.AddColumn(line);
                }
                else
                {
                    table.AddRow(line);
                }
            }
            table.Write(Format.Alternative);
        }

        static public double[,] Union(double[,] A, double[,] B)
        {
            if (A == null || B == null)
            {
                throw new ArgumentNullException();
            }

            // Объединение
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            double[,] result = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = Math.Max(A[i, j], B[i, j]);
                }
            }
            return result;
        }

        static public double[,] Intersect(double[,] A, double[,] B)
        {
            if (A == null || B == null)
            {
                throw new ArgumentNullException();
            }

            // Объединение
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            double[,] result = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = Math.Min(A[i, j], B[i, j]);
                }
            }
            return result;
        }

        static public double[,] Addition(double[,] A)
        {
            if (A == null)
            {
                throw new ArgumentNullException();
            }

            var result = new double[A.GetLength(0), A.GetLength(1)];

            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    result[i, j] = 1 - A[i, j];
                }
            }

            return result;
        }

        static public double[,] Compositional(double[,] A, double[,] B)
        {
            if (A == null || B == null)
            {
                throw new ArgumentNullException();
            }

            // Объединение
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            double[,] result = new double[n, m];

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    for (var k = 0; k < m; k++)
                    {                     
                        result[i, j] = Math.Max(Math.Min(A[i, k], B[k, j]),result[i,j]);                     
                    }
                }
            }
            return result;
        }
    }
}
