using System;
using System.Linq;
using System.Collections.Generic;
using ConsoleTables;

namespace LR2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://studizba.com/lectures/47-matematika/688-teoriya-prinyatiya-resheniy/13232-10-ponyatie-i-osnovnye-svoystva-nechetkih-otnosheniy.html


              double[,] A = new double[,]
              {
                      {0.3, 0.8, 0.5, 1.0 },
                      {0.0, 0.4, 0.3, 0.2 },
                      {0.7, 0.9, 1.0, 0.6 },
                      {0.1, 0.4, 0.8, 0.7 }
              };

              double[,] B = new double[,]
              {
                      {0.1, 0.6, 0.3, 0.8 },
                      {0.2, 1.0, 1.0, 0.5 },
                      {0.0, 0.4, 0.7, 0.9 },
                      {0.3, 0.1, 0.5, 0.6 }
              };

            /*
            double[,] A = new double[,] { 
                { 0.7, 0.8, 0.6, 0 },
                { 0.2, 0.3, 0.4, 0.5 },
                { 0.9, 0.2, 0.5, 1 },
                { 0.8, 0.5, 0.1, 0.4 }
            }; 

            double[,] B = new double[,] { 
                { 0.1, 0.2, 0.1, 0 },
                { 0.2, 0.2, 0.3, 0.4 },
                { 0.9, 0.2, 0, 0.1 }, 
                { 1, 0.5, 0.1, 0.6 } 
            };
            */

            Console.WriteLine("Объединение");
            FuzzyRelationships.Write(FuzzyRelationships.Union(A,B));
            Console.WriteLine();


            Console.WriteLine("Пересечение");
            FuzzyRelationships.Write(FuzzyRelationships.Intersect(A, B));
            Console.WriteLine();


            Console.WriteLine("Дополнение");
            FuzzyRelationships.Write(FuzzyRelationships.Addition(A));
            Console.WriteLine();

            Console.WriteLine("Композиция");
            FuzzyRelationships.Write(FuzzyRelationships.Compositional(A,B));
            Console.WriteLine();
        }
    }
}
