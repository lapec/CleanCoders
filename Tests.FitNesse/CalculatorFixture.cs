namespace Tests.FitNesse;

public class CalculatorFixture : fit.ColumnFixture
{
    public int Num1 { get; set; }
    public int Num2 { get; set; }

    public int Result()
    {
        return Num1 + Num2;
    }
}


