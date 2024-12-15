namespace Tests.FitNesse;

public class Testiranje
{
    public int Broj = 0;
    private decimal _balance;
    public void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        _balance -= amount;
    }

    public decimal GetBalance()
    {
        return _balance;
    }
}