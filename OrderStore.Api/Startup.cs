using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OrderStore.Core.Interfaces;
using OrderStore.Infrastructure.Data;
using OrderStore.Infrastructure.Repositories;

namespace OrderStore.Api
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
      services.AddDbContext<ApplicationDbContext>(
        m => m.UseSqlServer(
          Configuration.GetConnectionString("OrderStoreDB")), ServiceLifetime.Singleton);
      services.AddTransient<IOrderRepository, OrderRepository>();
      services.AddTransient<IProductRepository, ProductRepository>();
      services.AddTransient<IUnitOfWork, UnitOfWork>();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc(
          "v1",
          new OpenApiInfo { Title = "OrderStore", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(
          c => c.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "OrderStore v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
