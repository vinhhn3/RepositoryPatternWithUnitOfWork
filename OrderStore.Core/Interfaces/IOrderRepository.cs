using OrderStore.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderStore.Core.Interfaces
{
  public interface IOrderRepository : IGenericRepository<Order>
  {
    Task<IEnumerable<Order>> GetOrdersByOrderName(string orderName);
  }
}
