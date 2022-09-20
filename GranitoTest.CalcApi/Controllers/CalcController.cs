using GranitoTest.Application.Interfaces;
using GranitoTest.Application.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GranitoTest.CalcApi.Controllers
{
  [Route("api")]
  [ApiController]
  public class CalcController : ControllerBase
  {
    private readonly ITaxCalcService _taxCalcService;
    private readonly ITaxApiService _taxApiService;

    public CalcController(ITaxCalcService taxCalcService, ITaxApiService taxApiService)
    {
      _taxCalcService = taxCalcService;
      _taxApiService = taxApiService;
    }

    [HttpGet]
    [Route("calculajuros")]
    public async Task<IActionResult> GetCalculatedTax(double valorinicial, int meses)
    {
      double tax = await _taxApiService.GetTax();

      var apiReturn = new ApiReturn<string>
      {
        Success = true,
        Value = _taxCalcService.CalculateFinalValueWithTax(valorinicial, tax, meses).ToString("F"),
        Messages = null
      };
      
      return Ok(apiReturn);
    }

    [HttpGet]
    [Route("showmethecode")]
    public IActionResult GetUriGitHubProject()
    {
      return Ok(_taxApiService.GetUriGitHubProject());
    }
  }
}
