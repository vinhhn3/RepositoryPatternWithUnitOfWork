using System;
using System.Threading.Tasks;

namespace OrderStore.Core.Interfaces
{
  public interface IUnitOfWork : IDisposable
  {
    IOrderRepository Orders { get; }
    IProductRepository Products { get; }
    Task<int> Complete();
  }
}
