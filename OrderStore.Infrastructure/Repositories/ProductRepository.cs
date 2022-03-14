using OrderStore.Core.Interfaces;
using OrderStore.Core.Models;
using OrderStore.Infrastructure.Data;

namespace OrderStore.Infrastructure.Repositories
{
  public class ProductRepository : GenericRepository<Product>, IProductRepository
  {
    public ProductRepository(ApplicationDbContext context) : base(context)
    {

    }
  }
}

