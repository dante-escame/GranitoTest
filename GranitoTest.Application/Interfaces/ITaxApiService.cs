using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranitoTest.Application.Interfaces
{
  public interface ITaxApiService
  {
    Task<double> GetTax();
  }
}
