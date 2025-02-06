using Xunit;
using MyApp.Services;
public class CalculatorServiceTests
{
    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        // servisni olib kelish
        var service = new CalculatorService();
        // servisdan natija olish
        var result = service.Add(2, 3);
        // kutilayotgan natija bilan tenglash
        Assert.Equal(5, result);
    }

    [Fact]
    public void Multiple_ShouldReturnCorrect()
    {
        var service = new CalculatorService();
        var result = service.Multiple(10, 2);
        List<List<int>> results = [
            [1,2,2],
            [2,3,6],
            [10,3,30],
            [100,4,400],
            [121,3,363],

        ];
        for (int i = 0; i < results.Count(); i++)
        {
            Assert.Equal(results[i][2], service.Multiple(results[i][0], results[i][1]));
        }
    }

    [Fact]
    public void Division_ShouldReturnCorrect()
    {
        //...
    }

    [Fact]
    public void Avg_ShouldReturnCorrect()
    {
        //
    }
}
