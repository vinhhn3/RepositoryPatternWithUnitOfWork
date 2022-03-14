using OrderStore.Core.Interfaces;
using OrderStore.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace OrderStore.Infrastructure.Repositories
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApplicationDbContext _context;
    public IOrderRepository Orders { get; }
    public IProductRepository Products { get; }

    public UnitOfWork(ApplicationDbContext _context,
        IOrderRepository booksRepository,
        IProductRepository catalogueRepository)
    {
      this._context = _context;

      this.Orders = booksRepository;
      this.Products = catalogueRepository;
    }
    public async Task<int> Complete()
    {
      return await _context.SaveChangesAsync();
    }
    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        _context.Dispose();
      }
    }
  }
}
