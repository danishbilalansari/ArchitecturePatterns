using ArchitecturePatterns.EDD.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArchitecturePatterns.EDD.API.Controllers;

/// <summary>
/// Controller responsible for handling order-related HTTP requests
/// in the Event-Driven Design (EDD) architecture.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderService _orderService;

    /// <summary>
    /// Constructor that injects the OrderService dependency.
    /// </summary>
    /// <param name="orderService">The service that handles order placement logic and event publishing.</param>
    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }

    /// <summary>
    /// Places a new order for a specified product and quantity.
    /// This endpoint triggers domain logic and publishes corresponding events.
    /// </summary>
    /// <param name="productName">The name of the product to order.</param>
    /// <param name="quantity">The quantity to order.</param>
    /// <returns>200 OK with confirmation message upon successful order placement.</returns>
    [HttpPost("place")]
    public async Task<IActionResult> PlaceOrder(string productName, int quantity)
    {
        await _orderService.PlaceOrderAsync(productName, quantity);
        return Ok("Order placed successfully.");
    }
}
