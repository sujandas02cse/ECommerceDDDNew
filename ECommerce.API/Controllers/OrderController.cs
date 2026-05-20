using ECommerce.Application.DTOs;
using ECommerce.Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [ApiController]

    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]

        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDTO request)

        {

            try

            {

                int newOrderId = await _orderService.PlaceOrderAsync(request);

                return Ok(new

                {

                    Message = "Order placed successfully",

                    OrderId = newOrderId

                });

            }

            catch (Exception ex)

            {

                return BadRequest(new { Error = ex.Message });

            }

        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetOrder(int id)

        {

            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)

                return NotFound();



            return Ok(order);

        }
    }
}
