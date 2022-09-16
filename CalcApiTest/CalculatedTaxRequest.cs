using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranitoTest.Tests
{
  public class CalculatedTaxRequest
  {
    public double initialValue { get; set; }
    public int months { get; set; }
    public double tax { get; set; }
    public double expectedResult { get; set; }
  }
}
