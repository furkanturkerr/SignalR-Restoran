using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        
        [HttpGet("TotalOrderCount")]
        public IActionResult TotalOrderCount()
        {
            var values = _orderService.TTotalOrderCount();
            return Ok(values);
        }
        
        [HttpGet("ActiveOrderCount")]
        public IActionResult ActiveOrderCount()
        {
            var values = _orderService.TActiveOrderCount();
            return Ok(values);
        }
        
        [HttpGet("LastOrderTotalPrice")]
        public IActionResult LastOrderTotalPrice()
        {
            var values = _orderService.TLastOrderTotalPrice();
            return Ok(values);
        }
    }
