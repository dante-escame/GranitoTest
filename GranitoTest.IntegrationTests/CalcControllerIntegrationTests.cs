using FakeItEasy;
using GranitoTest.Application.Interfaces;
using GranitoTest.CalcApi;
using GranitoTest.CalcApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using Xunit;

namespace CalcApiTest
{
  public class CalcControllerIntegrationTests
  {
    private readonly WebApplicationFactory<Startup> _factory;

    public CalcControllerIntegrationTests(WebApplicationFactory<Startup> factory)
    {
      _factory = factory;
    }

    [Fact]
    public async Task GetCalculatedTax_WhenCalled_EndPointsReturnsSuccessAndCorrectValue()
    {
      // Arrange
      /*var application = new WebApplicationFactory<Program>()
        .WithWebHostBuilder(builder =>
        {
          // ... Configure test services
        });*/

      //var client = application.CreateClient();

      var client = _factory.CreateClient(); // _todo_ usar webapplication factory
      var fakeITaxCalcService = A.Fake<ITaxCalcService>(); // interface fake - fakeiteasy
      var fakeITaxApiService = A.Fake<ITaxApiService>(); // interface fake
      // instancia do controller
      //CalcController calcController = new CalcController(fakeITaxCalcService, fakeITaxApiService);

      // Act
      var response = await client.GetAsync("http://127.0.0.1:5001/api/Calc?initialValue=100&months=5");

      // Assert
      response.EnsureSuccessStatusCode(); // Status Code 200-299
      Assert.Equal("text/html; charset=utf-8",
          response.Content.Headers.ContentType.ToString());
    }

    [Fact]
    public void GetUriGitHubProject_WhenCalled_ReturnsOk()
    {
      // Arrange
      var fakeITaxCalcService = A.Fake<ITaxCalcService>();
      var fakeITaxApiService = A.Fake<ITaxApiService>();

      var calcController = new CalcController(fakeITaxCalcService, fakeITaxApiService);

      // Act
      var result = calcController.GetUriGitHubProject();

      // Assert
      Assert.IsType<OkObjectResult>(result);
    }
  }
}
