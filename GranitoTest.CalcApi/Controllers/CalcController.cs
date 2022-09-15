using GranitoTest.Application;
using GranitoTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GranitoTest.CalcApi.Controllers
{
  [ApiController]
  public class CalcController : ControllerBase
  {
    private readonly ITaxCalcService _taxCalcService;
    private readonly ITaxApiService _taxApiService;
    private readonly string _uriGitHubProject;

    public CalcController(ITaxCalcService taxCalcService, ITaxApiService taxApiService, GeneralUriConfiguration generalUriConfiguration)
    {
      _taxCalcService = taxCalcService;
      _taxApiService = taxApiService;
      _uriGitHubProject = generalUriConfiguration.GitHubProject;
    }

    [HttpGet]
    [Route("calculajuros")]
    public async Task<IActionResult> GetCalculatedTax(double initialValue, int meses)
    {
      double tax = await _taxApiService.GetTax();
      return Ok(_taxCalcService.CalculateFinalValueWithTax(initialValue, tax, meses).ToString("F"));
    }

    [HttpGet]
    [Route("showmethecode")]
    public IActionResult GetUriGitHubProject()
    {
      return Ok(_uriGitHubProject);
    }
  }
}
