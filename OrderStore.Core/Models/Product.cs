using System.ComponentModel.DataAnnotations;

namespace OrderStore.Core.Models
{
  public class Product
  {
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public bool isDisCountApplied { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
  }
}

