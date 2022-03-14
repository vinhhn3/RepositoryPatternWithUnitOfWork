using Microsoft.EntityFrameworkCore;
using OrderStore.Core.Interfaces;
using OrderStore.Core.Models;
using OrderStore.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderStore.Infrastructure.Repositories
{
  public class OrderRepository : GenericRepository<Order>, IOrderRepository
  {
    public OrderRepository(ApplicationDbContext context) : base(context)
    {

    }
    public async Task<IEnumerable<Order>> GetOrdersByOrderName(string orderName)
    {
      return await _context.Orders
        .Where(c => c.OrderDetails.Contains(orderName))
        .ToListAsync();
    }
  }
}

