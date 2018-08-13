using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using EquationBalancer.Helpers;

namespace EquationBalancer
{
    class Program
    {
        static void Main(string[] args)
        {

            //const string equation = "NaOH + Cl2 + Ca(OH)2 => NaClO + NaCl + H2O";

            //(var right, var left) = Calculator.SplitEquation(equation);

            //foreach (var val in left)
            //{
            //    var formula = Calculator.FormulaFromString(val);

            //    foreach (var element in formula)
            //        Console.WriteLine($"{element.Element.Name}: {element.AtomCount}");

            //    //Console.WriteLine(val);
            //}

            var testCases = new List<string>
            {
                "CaOH2",
                "O3"
            };

            foreach (var testCase in testCases)
            {
                var formula = Calculator.FormulaFromString(testCase);

                foreach (var element in formula)
                {
                    Console.WriteLine(element.Element.Name);
                }
            }

            //int[,] matrix = new int[2, 2] { { 2, 2 }, { 1, 1 } };
            double[,] matrix = new double[4, 4] { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 1, 1, 1, 1 } };


            //for (var i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (var j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        Console.Write($"{matrix[i, j]} ");
            //    }

            //    Console.WriteLine();
            //}

            //var matrixString = new StringBuilder();
            //for (var i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (var j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        matrixString.Append(matrix[i, j]);
            //        matrixString.Append(" ");
            //    }

            //    matrixString.AppendLine();
            //}

            var nMat = new Matrix(matrix);
            var nMat2 = new Matrix(matrix);

            Matrix nMat3 = nMat2 + nMat;

            var nMat4 = nMat.Transpose();

            var mat5 = new Matrix(new double[2, 2] { { 2, 2 }, { 2, 2 } });
            var mat6 = new Matrix(new double[2, 2] { { 2, 2 }, { 2, 2 } });

            //string matString = nMat.ToString();
            var ans = mat6 * mat5;

            Console.WriteLine(ans);

            var mat8 = new Matrix(5, 1);
            Console.WriteLine(mat8);


            //Console.WriteLine(nMat);
            //Console.WriteLine(nMat3);
            //Console.WriteLine(nMat4);
            //return matrixString.ToString();

            Console.ReadKey();
        }

        
    }

}
