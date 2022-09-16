using FakeItEasy;
using GranitoTest.Application.Interfaces;
using GranitoTest.CalcApi.Controllers;
using GranitoTest.Tests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CalcApiTest
{
  public class CalcControllerTest
  {
    [Fact]
    public void GetCalculatedTax_WhenCalled_ReturnsCorrectCalculatedTax()
    {
      // Arrange
      var fakeITaxCalcService = A.Fake<ITaxCalcService>(); // interface fake - fakeiteasy
      var fakeITaxApiService = A.Fake<ITaxApiService>(); // interface fake

      // instancia do controller
      CalcController calcController = new CalcController(fakeITaxCalcService, fakeITaxApiService);

      // Act
      var trueResult = calcController.GetCalculatedTax(100, 5);

      // Assert
      Assert.IsType<OkObjectResult>(trueResult);
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
