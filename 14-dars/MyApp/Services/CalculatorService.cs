namespace MyApp.Services;

public interface ICalculatorService
{
    int Add(int a, int b);
}
public class CalculatorService : ICalculatorService
{
    public int Add(int a, int b) => a + b;
    public int Multiple(int a, int b) => a * b;
    public int? Division(int a, int b)
    {
        if (b == 0)
        {
            return null;
        }
        return a / b;
    }

    public int Avg(int a, int b)
    {
        return (a + b) / 2;
    }
}
