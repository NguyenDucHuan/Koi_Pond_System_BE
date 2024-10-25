using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Constants;
using KPCOS.Api.Service.Interface;
using KPOCOS.Domain.DTOs.Response;
using KPOCOS.Domain.DTOs.Resquest;
using KPOCOS.Domain.Errors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;

        public OrderController(IOrderService orderService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
        }


        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpPost("create-order")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest orderRequest)
        {
            var createOrderResponse = await _orderService.CreateOrder(orderRequest);
            return Ok(createOrderResponse);
        }

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpPut("update-order-item-status/{orderItemId}")]
        public async Task<IActionResult> UpdateOrderItemStatus([FromRoute] int orderItemId, [FromBody] string status)
        {
            var createOrderResponse = await _orderItemService.UpdateOrderItemStatus(orderItemId, status);
            return Ok(createOrderResponse);
        }

        [ProducesResponseType(typeof(GetOrderDetailResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpGet("get-order/{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] int orderId)
        {
            var orderItem = await _orderService.GetOrderAsync(orderId);
            return Ok(orderItem);
        }
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpPost("update-order-status")]
        public async Task<IActionResult> UpdateOrderIStatus([FromRoute] int orderId, string status)
        {
            var Response = _orderService.UpdateOrderStatus(orderId, status);
            return Ok(Response);
        }

        [ProducesResponseType(typeof(List<GetOrderDetailResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }

        [ProducesResponseType(typeof(List<UpdateOrderRequest>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Error), StatusCodes.Status500InternalServerError)]
        [Consumes(MediaTypeConstant.ApplicationJson)]
        [Produces(MediaTypeConstant.ApplicationJson)]
        [HttpPut("update-order")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderRequest orderRequest)
        {
            var createOrderResponse = await _orderService.UpdateOrderAsync(orderRequest);
            return Ok(createOrderResponse);
        }
    }
}