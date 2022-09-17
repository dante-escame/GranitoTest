using GranitoTest.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GranitoTest.Tests
{
  public class TaxCalcServiceUnitTest
  {
    [Fact]
    public void CalculateFinalValueWithTax_WhenCalled_ReturnsCorrectCalculatedTax()
    {
      // Arrange
      var service = new TaxCalcService();

      var request = new CalculatedTaxRequest
      {
        initialValue = 100,
        months = 5,
        tax = 0.01,
        expectedResult = 105.1
      };

      // Act
      var result = service.CalculateFinalValueWithTax(request.initialValue, request.tax, request.months);

      // Assert
      Assert.Equal<double>(request.expectedResult, result);
    }
  }
}
