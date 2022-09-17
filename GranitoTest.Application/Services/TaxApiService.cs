using GranitoTest.Application.Interfaces;
using System.Net.Http;
using System.Threading.Tasks;

namespace GranitoTest.Application.Services
{
  public class TaxApiService : ITaxApiService
  {
    private readonly GeneralUriConfiguration _generalUriConfiguration;

    public TaxApiService(GeneralUriConfiguration generalUriConfiguration)
    {
      _generalUriConfiguration = generalUriConfiguration;
    }

    public async Task<double> GetTax()
    {
      var httpClient = new HttpClient();
      var response = await httpClient.GetAsync(_generalUriConfiguration.TaxApi);

      string apiResponse = await response.Content.ReadAsStringAsync();
      return double.Parse(apiResponse, System.Globalization.CultureInfo.InvariantCulture);
    }

    public string GetUriGitHubProject()
    {
      return _generalUriConfiguration.GitHubProject;
    }
  }
}
