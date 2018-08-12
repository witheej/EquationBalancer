namespace EquationBalancer
{
    public class ChemicalElement
    {

        public ChemicalElement(string symbol)
        {
            Name = symbol;
        }

        public int AtomicNumber { get; set; }
        public string Name { get;}
        public string Symbol { get; set; }

    }
}