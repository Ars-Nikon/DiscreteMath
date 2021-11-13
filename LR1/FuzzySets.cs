using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR1
{
    static class FuzzySets
    {
        static public Dictionary<string, double> RandomFuzzy(int count)
        {
            var RandomFuzzy = new Dictionary<string, double>();

            var random = new Random();

            for (int i = 65, j = 0; j < count; j++, i++)
            {
                if (i == 91)
                {
                    i = 65;
                }
                string key;
                if (j > 25)
                {
                    key = ((char)i).ToString() + j;
                }
                else
                {
                    key = ((char)i).ToString();
                }
                RandomFuzzy.Add(key, Math.Round(random.NextDouble(), 1));
            }

            return RandomFuzzy;
        }



        static public void WriteFuzzy<T>(Dictionary<T, double> A)
        {
            if (A == null)
            {
                throw new ArgumentNullException();
            }

            var table = new ConsoleTable("Key", "Value");
            foreach (var item in A)
            {
                table.AddRow(item.Key, Math.Round(item.Value,1));
            }
            table.Write();
        }

        static public Dictionary<T, double> Union<T>(Dictionary<T, double> A, Dictionary<T, double> B)
        {
            return A.Union(B).
                Where(x => x.Value >= (B.ContainsKey(x.Key) ? B.GetValueOrDefault(x.Key) : x.Value)).
                GroupBy(x => x.Key).Select(g => g.First()).
                ToDictionary(x => x.Key, y => y.Value);
        }

        static public Dictionary<T, double> Intersect<T>([NotNull] Dictionary<T, double> A, [NotNull] Dictionary<T, double> B)
        {
            return A.Union(B).
                  Where(x => x.Value <= (B.ContainsKey(x.Key) ? B.GetValueOrDefault(x.Key) : x.Value)).
                  GroupBy(x => x.Key).Select(g => g.First()).
                  ToDictionary(x => x.Key, y => y.Value);
        }

        static public Dictionary<T, double> Except<T>([NotNull] Dictionary<T, double> A, [NotNull] Dictionary<T, double> B)
        {
            var AllLotsOf = A.Union(B).
                GroupBy(x => x.Key).
                Select(g => g.First()).
                ToDictionary(x => x.Key, y => y.Value);

            var Except = new Dictionary<T, double>();

            foreach (var item in AllLotsOf)
            {
                if (B.ContainsKey(item.Key) && A.ContainsKey(item.Key))
                {
                    if (B[item.Key] > A[item.Key])
                    {
                        Except.Add(item.Key, 0);
                    }
                    else
                    {
                        Except.Add(item.Key, item.Value - (B[item.Key]));
                    }
                }
                else
                {
                    Except.Add(item.Key, B.ContainsKey(item.Key) ? B[item.Key] : A[item.Key]);
                }
            }
            return Except;
        }

        static public Dictionary<T, double> Addition<T>([NotNull] Dictionary<T, double> A)
        {
            return A.Select(x => new { Key = x.Key, Value = 1 - x.Value }).
                ToDictionary(x => x.Key, y => y.Value);
        }

        static public Dictionary<T, double> MultipleLevelsFoFour<T>([NotNull] Dictionary<T, double> A)
        {
            return A.Where(x => x.Value >= 0.4).
                ToDictionary(x => x.Key, y => y.Value);
        }

        static public Dictionary<T, double> SymmetricDifference<T>([NotNull] Dictionary<T, double> A, [NotNull] Dictionary<T, double> B)
        {
            var Except_A = Except<T>(A, B);
            var Except_B = Except<T>(B, A);

            return Except_A.Union(Except_B).
                Where(x => x.Value >= (Except_B.ContainsKey(x.Key) ? Except_B.GetValueOrDefault(x.Key) : x.Value)).
                GroupBy(x => x.Key).Select(g => g.First()).
                ToDictionary(x => x.Key, y => y.Value);
        }

    }
}
