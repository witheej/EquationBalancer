using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace EquationBalancer
{
    public class Calculator
    {
        private const string Element = "([A-Z][a-z]*)([0-9]*)";
        private const string ElementValidation = "^(" + Element + ")+$";
        private const string EquationValidation = "";

        public static ICollection<ChemicalFormulaComponent> FormulaFromString(string chemicalFormula)
        {
            var formula = new Collection<ChemicalFormulaComponent>();            

            if (!Regex.IsMatch(chemicalFormula, ElementValidation))
                throw new FormatException("Formula not in correct format");

            foreach (Match match in Regex.Matches(chemicalFormula, Element))
            {
                string name = match.Groups[1].Value;
                int count =
                    match.Groups[2].Value != "" ? int.Parse(match.Groups[2].Value) : 1;

                var elementName = new ChemicalElement(name);

                formula.Add(new ChemicalFormulaComponent
                {
                    Element = elementName,
                    AtomCount = count
                });
            }

            return formula;
        }

        public static (List<string> RHS, List<string> LHS) SplitEquation(string equation)
        {
            if (!Regex.IsMatch(equation, EquationValidation))
                throw new FormatException("Equation not in correct format.");

            string[] leftAndRight = equation.Split("=>");

            string[] leftHandSide = leftAndRight[0].Split("+");

            for (var i = 0; i < leftHandSide.Length; i++)
            {
                leftHandSide[i] = leftHandSide[i].Trim();
            }

            string[] rightHandSide = leftAndRight[1].Split("+");

            for (var i = 0; i < rightHandSide.Length; i++)
            {
                rightHandSide[i] = rightHandSide[i].Trim();
            }


            return (RHS: rightHandSide.ToList(), LHS: leftHandSide.ToList());

        }

    }
}