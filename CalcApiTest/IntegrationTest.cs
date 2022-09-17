using FakeItEasy;
using GranitoTest.Application.Interfaces;
using GranitoTest.CalcApi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net.Http;

namespace GranitoTest.Tests
{
  public class IntegrationTest
  {
    protected readonly HttpClient TestClient;

    protected IntegrationTest()
    {
      var fakeITaxApiService = A.Fake<ITaxApiService>();
      A.CallTo(() => fakeITaxApiService.GetTax()).Returns(0.01);

      var appFactory = new WebApplicationFactory<Startup>()
        .WithWebHostBuilder(builder => 
        {
          builder.ConfigureTestServices(services =>
          {
            services.RemoveAll(typeof(ITaxApiService));
            services.TryAddSingleton(fakeITaxApiService);
          });
        });

      TestClient = appFactory.CreateClient();
    }
  }
}
