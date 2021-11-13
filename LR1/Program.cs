using System;
using System.Collections.Generic;
using System.Linq;

namespace LR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var A = new Dictionary<string, double>()
            {
                {"a", 0.2},
                {"b", 0.3},
                {"g", 0.4},
                {"f", 1.0},
                {"r", 0.6},
                {"y", 0.3},
                {"k", 0.2},
                {"d", 0.2},
                {"l", 0.1},
                {"s", 0.1},
            };

            var B = new Dictionary<string, double>()
            {
                {"w", 0.1},
                {"q", 0.2},
                {"a", 0.3},
                {"d", 0.4},
                {"b", 0.8},
                {"t", 1.0},
                {"j", 0.5},
                {"l", 0.4},
                {"g", 0.3},
                {"h", 0.1},
            };

            Console.WriteLine("Начальное Множество А");
            FuzzySets.WriteFuzzy(A);

            Console.WriteLine("Начальное Множество B");
            FuzzySets.WriteFuzzy(B);

            Console.WriteLine("А объединение В");
            FuzzySets.WriteFuzzy(FuzzySets.Union(A, B));

            Console.WriteLine("А пересечение В");
            FuzzySets.WriteFuzzy(FuzzySets.Intersect(A, B));

            Console.WriteLine("А разность В");
            FuzzySets.WriteFuzzy(FuzzySets.Except(A, B));

            Console.WriteLine("B разность A");
            FuzzySets.WriteFuzzy(FuzzySets.Except(B, A));

            Console.WriteLine("A дополнение");
            FuzzySets.WriteFuzzy(FuzzySets.Addition(A));

            Console.WriteLine("Множество уровня 0.4 B");
            FuzzySets.WriteFuzzy(FuzzySets.MultipleLevelsFoFour(B));

            Console.WriteLine("A Симметрическая разность B");
            FuzzySets.WriteFuzzy(FuzzySets.SymmetricDifference(A,B));
        }
    }
}
