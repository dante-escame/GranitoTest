using GranitoTest.Application.Utils;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace GranitoTest.Tests
{
  public class CalcControllerIntegrationTest : IntegrationTest
  {
    [Fact]
    public async Task GetCalculatedTax_WhenCalled_ReturnsSuccessCodeAndCorrectTaxValue()
    {
      // Arrange
      var requestData = new CalculatedTaxRequest
      {
        initialValue = 100,
        months = 5,
        tax = 0.01,
        expectedResult = 105.1
      };

      // Act
      var response = await TestClient.GetAsync("http://127.0.0.1:5000/api/calculajuros?valorinicial=100&meses=5");
      string apiResponse = await response.Content.ReadAsStringAsync();

      // Assert
      response.EnsureSuccessStatusCode();
      Assert.Equal("{\"success\":true,\"value\":\"105,10\",\"messages\":null}", apiResponse);
    }

    [Fact]
    public async Task GetUriGitHubProject_WhenCalled_ReturnsOk()
    {
      // Arrange
      var request = "http://127.0.0.1:5000/api/showmethecode";
      
      // Act
      var response = await TestClient.GetAsync(request);

      // Assert
      response.EnsureSuccessStatusCode();
    }
  }
}
