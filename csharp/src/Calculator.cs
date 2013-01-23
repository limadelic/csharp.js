namespace Math
{
    public class Calculator
    {
        public int Result = 42;

        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Subtract(int x, int y)
        {
            return x - y;
        }

        public string Add(int x, int y, string units)
        {
            return string.Format("{0} {1}", Add(x, y), units);
        }

        public double Div(int x, int y)
        {
            return x / y;
        }
    }
}
