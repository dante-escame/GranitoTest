using Microsoft.AspNetCore.Mvc;

namespace GranitoTest.TaxApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TaxController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetTaxRate()
    {
      return Ok(0.01); // _todo_
      // REST Pattern - return code
    }
  }
}
