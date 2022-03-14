using Microsoft.EntityFrameworkCore;
using OrderStore.Core.Models;

namespace OrderStore.Infrastructure.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    { }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }

  }
}
