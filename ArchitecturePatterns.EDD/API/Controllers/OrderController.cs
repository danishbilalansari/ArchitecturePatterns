using ArchitecturePatterns.EDD.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatterns.EDD.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost("place")]
    public async Task<IActionResult> PlaceOrder(string productName, int quantity)
    {
        await _orderService.PlaceOrderAsync(productName, quantity);
        return Ok("Order placed successfully.");
    }
}