namespace Tests.FitNesse;

public class Calculator: fit.ColumnFixture
{
    public double volts;

    public double watts()
    {
        return 0.500;
    }

    public bool points()
    {
        return volts <= 3.30;
    }
}