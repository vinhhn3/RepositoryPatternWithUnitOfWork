using Microsoft.AspNetCore.Mvc;
using OrderStore.Core.Interfaces;
using System.Threading.Tasks;

namespace OrderStore.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class OrdersController : ControllerBase
  {
    private readonly IUnitOfWork _unitOfWork;
    public OrdersController(IUnitOfWork unitOfWork)
    {
      _unitOfWork = unitOfWork;
    }

    // GET: api/<Books>
    [HttpGet(nameof(GetOrders))]
    public async Task<IActionResult> GetOrders() => Ok(await _unitOfWork.Orders.GetAll());

    [HttpGet(nameof(GetOrderByName))]
    public async Task<IActionResult> GetOrderByName([FromQuery] string Genre) => Ok(await _unitOfWork.Orders.GetOrdersByOrderName(Genre));

  }
}
