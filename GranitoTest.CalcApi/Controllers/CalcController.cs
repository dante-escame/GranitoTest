using GranitoTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
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
    public async Task<IActionResult> GetCalculatedTax(double initialValue, int months)
    {
      double tax = await _taxApiService.GetTax();
      return Ok(_taxCalcService.CalculateFinalValueWithTax(initialValue, tax, months).ToString("F"));
    }

    [HttpGet]
    [Route("showmethecode")]
    public IActionResult GetUriGitHubProject()
    {
      return Ok(_taxApiService.GetUriGitHubProject());
    }
  }
}
