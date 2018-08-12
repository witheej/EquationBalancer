using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

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
                "Ca(OH)2",
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

            Console.ReadKey();
        }

        
    }

}
