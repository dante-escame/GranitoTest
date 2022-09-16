namespace GranitoTest.Application.Interfaces
{
  public interface ITaxCalcService
  {
    double CalculateFinalValueWithTax(double initialValue, double tax, int months);
  }
}