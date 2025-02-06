// using System.Net.Http;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc.Testing;
// using Xunit;

// public class CalculatorControllerTests : IClassFixture<WebApplicationFactory<Program>>
// {
//     private readonly HttpClient _client;
//     public CalculatorControllerTests(WebApplicationFactory<Program> factory)
//     {
//         _client = factory.CreateClient();
//     }
//     [Fact]
//     public async Task Add_ReturnsCorrectSum()
//     {
//         var response = await _client.GetAsync("/api/calculator/add?a=2&b=3");
//         response.EnsureSuccessStatusCode();
//         var result = await response.Content.ReadAsStringAsync();
//         Assert.Equal("5", result);
//     }
// }
