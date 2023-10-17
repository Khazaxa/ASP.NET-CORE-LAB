using Lab2.Models;

namespace Lab2.Models
{
    public class Calculator
    {
        public Operators? Operator { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        private Dictionary<Operators, String> _opDict = new Dictionary<Operators, string>()
        {
            { Operators.ADD, "+"},
            { Operators.SUB, "-"},
            { Operators.MUL, "&times;"},
            { Operators.DIV, "&divide;"},

        };

        public string Op
        {
            get
            {
                return _opDict[Operator??Operators.ADD];
            }
        }
        public bool IsValid()
        {
            return Operator != null && X != null && Y != null;
        }
        public double Calculate()
        {
            switch (Operator)
            {
                case Operators.ADD:
                    return (double)X + Y;
                    break;

                case Operators.SUB:
                    return (double)X - Y;
                    break;
                case Operators.MUL:
                    return (double)X * Y;
                    break;
                case Operators.DIV:
                    return (double)X / Y;
                    break;

                default: return double.NaN;
            }
        }


    }
}
