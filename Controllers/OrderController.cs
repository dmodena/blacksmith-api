using BlacksmithAPI.Models;using BlacksmithAPI.Services;using Microsoft.AspNetCore.Mvc;

namespace BlacksmithAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service) => _service = service;

    [HttpPost(Name = "Request Order")]
    public Order RequestOrder([FromBody] OrderRequest request)
    {
        return _service.RequestOrder(request);
    }
}
