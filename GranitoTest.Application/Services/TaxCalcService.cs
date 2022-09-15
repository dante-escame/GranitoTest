using GranitoTest.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace GranitoTest.Application.Services
{
  public class TaxCalcService : ITaxCalcService
  {
    public double CalculateFinalValueWithTax(double initialValue, double tax, int meses)
    {
      return initialValue * Math.Pow(1 + tax, meses);
    }
  }
}
