using GranitoTest.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GranitoTest.Application.Services
{
  public class TaxApiService : ITaxApiService
  {
    private readonly string _uriTaxApi;

    public TaxApiService(GeneralUriConfiguration generalUriConfiguration)
    {
      _uriTaxApi = generalUriConfiguration.TaxApi;
    }

    public async Task<double> GetTax()
    {
      var httpClient = new HttpClient();
      var response = await httpClient.GetAsync(_uriTaxApi);

      string apiResponse = await response.Content.ReadAsStringAsync();
      return double.Parse(apiResponse, System.Globalization.CultureInfo.InvariantCulture);
    }
  }
}
