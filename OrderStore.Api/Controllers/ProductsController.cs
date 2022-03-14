using Microsoft.AspNetCore.Mvc;
using OrderStore.Core.Interfaces;
using OrderStore.Core.Models;

namespace OrderStore.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;
    public ProductsController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    [HttpPost(nameof(CreateProduct))]
    public IActionResult CreateProduct(Product product)
    {
      var result = _unitOfWork.Products.Add(product);
      _unitOfWork.Complete();
      if (result != null) return Ok("Product Created");
      else return BadRequest("Error in Creating the Product");
    }

    [HttpPut(nameof(UpdateProduct))]
    public IActionResult UpdateProduct(Product product)
    {
      _unitOfWork.Products.Update(product);
      _unitOfWork.Complete();
      return Ok("Product Updated");
    }
  }
}
