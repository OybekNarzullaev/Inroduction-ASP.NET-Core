using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;
using OnlineMarket.Data;
using Xunit;

namespace OnlineMarket.Tests;
public class OnlineMarketE2ETests : IAsyncLifetime
{

    private IPlaywright _playwright;
    private IBrowser _browser;
    private IBrowserContext _context;
    private IPage _page;


    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        _context = await _browser.NewContextAsync();
        _page = await _context.NewPageAsync();
    }

    [Fact]
    public async Task User_Can_Register()
    {

        await _page.GotoAsync("http://localhost:5243/Auth/Register");


        await _page.FillAsync("#FirstName", "John");
        await _page.FillAsync("#LastName", "Doe");
        await _page.FillAsync("#Email", "oybek@example.com");

        var dateOfBirthLocator = _page.Locator("#DateOfBirth");
        await dateOfBirthLocator.WaitForAsync(new() { State = WaitForSelectorState.Visible });
        await dateOfBirthLocator.FillAsync("1999-03-01");

        await _page.FillAsync("#Password", "Test@1234");
        await _page.FillAsync("#ConfirmPassword", "Test@1234");


        await _page.ClickAsync("#register-button");


        var userNameLocator = _page.Locator("#user-name");
        var userName = await userNameLocator.TextContentAsync();
        Assert.Contains("oybek@example.com", userName);
        using (var client = new HttpClient())
        {
            var response = await client.DeleteAsync("http://localhost:5243/Auth/DeleteTestUsers");
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        }

    }

    [Fact]
    public async Task User_Can_View_Products()
    {
        await _page.GotoAsync("http://localhost:5243/");

        var products = await _page.Locator("#products").CountAsync();
        Assert.True(products > 0);
    }

    public async Task DisposeAsync()
    {
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}
