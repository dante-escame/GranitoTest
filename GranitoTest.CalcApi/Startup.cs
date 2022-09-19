using GranitoTest.Application;
using GranitoTest.Application.Interfaces;
using GranitoTest.Application.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GranitoTest.CalcApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();

      // injecao de dependencia(servicos)
      services.AddScoped<ITaxCalcService, TaxCalcService>();
      services.AddScoped<ITaxApiService, TaxApiService>();

      // URIs (TaxApi e link do projeto do Github)
      GeneralUriConfiguration generalUriConfiguration = new GeneralUriConfiguration();
      Configuration.GetSection("Uri").Bind(generalUriConfiguration);
      // injecao de dependencia - lifetime da API(singleton)
      services.AddSingleton(generalUriConfiguration);

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "GranitoTest.CalcApi", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      /*if (env.IsDevelopment())
      {*/
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GranitoTest.CalcApi v1"));
      //}

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
