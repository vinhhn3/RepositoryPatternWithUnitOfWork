using Microsoft.Extensions.DependencyInjection;
using OrderStore.Core.Interfaces;
using OrderStore.Infrastructure.Repositories;

namespace OrderStore.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
      services.AddTransient<IOrderRepository, OrderRepository>();
      services.AddTransient<IProductRepository, ProductRepository>();
      services.AddTransient<IUnitOfWork, UnitOfWork>();

      return services;
    }
  }
}
