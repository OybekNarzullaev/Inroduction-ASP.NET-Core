
using Microsoft.Playwright;
using Xunit;
using OpenQA.Selenium.Chrome;


public class E2ETests
{

    [Fact]
    public void PageTitle_ShouldBeCorrect()
    {
        using var driver = new ChromeDriver();

        driver.Navigate().GoToUrl("http://localhost:5052");
        var title = driver.Title;


        Assert.Equal("Home Page - MyApp", title);
    }


}
