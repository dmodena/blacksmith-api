using BlacksmithAPI.Models;using BlacksmithAPI.Services;using Microsoft.AspNetCore.Mvc;

namespace BlacksmithAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    [HttpPost(Name = "Request Order")]
    public Order RequestOrder([FromBody] OrderRequest request)
    {
        var service = new OrderService();
        return service.RequestOrder(request);
    }
}
