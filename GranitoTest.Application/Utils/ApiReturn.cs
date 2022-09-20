using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GranitoTest.Application.Utils
{
  public class ApiReturn<T>
  {
    public bool Success { get; set; }
    public T? Value { get; set; }
    public List<string> Messages { get; set; } = new();
  }
}
