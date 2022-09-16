using GranitoTest.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace GranitoTest.Application.Services
{
  public class TaxCalcService : ITaxCalcService
  {
    public double CalculateFinalValueWithTax(double initialValue, double tax, int meses)
    {
      return Math.Truncate(initialValue * Math.Pow(1 + tax, meses) * 100) / 100;
    }
  }
}
