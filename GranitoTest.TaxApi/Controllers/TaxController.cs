using Microsoft.AspNetCore.Mvc;

namespace GranitoTest.TaxApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TaxController : ControllerBase
  {
    [HttpGet]
    public IActionResult GetTaxRate()
    {
      return Ok(0.01);

    }
  }
}
