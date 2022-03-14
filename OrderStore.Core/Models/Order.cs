using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderStore.Core.Models
{
  public class Order
  {
    [Key]
    public int Id { get; set; }
    public string OrderDetails { get; set; }
    public bool IsActive { get; set; }
    public DateTime OrderedDate { get; set; }
    public List<Product> Products { get; set; }
  }
}

