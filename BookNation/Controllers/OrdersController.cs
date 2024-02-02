using BookNation.Data;
using BookNation.DTO;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Controllers
{
    public class OrdersController : BaseApiController
    {
        private readonly DataContext _context;

        public OrdersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int userId)
        {
            var orders = await _context.Orders.Where(order => order.AppUserId == userId).ToListAsync();
            orders.ForEach(async order =>
            {
                order.OrderItems = await _context.OrderItems.Where(item => item.OrderId == order.Id).ToListAsync();
            });

            return orders;
        }

        [HttpGet("GetOrder/{userId}/{orderId}")]
        public async Task<ActionResult<Order>> GetOrder(int userId, int orderId)
        {
            var order = await _context.Orders.Where(order => order.AppUserId == userId && order.Id == orderId).FirstOrDefaultAsync();
            order.OrderItems = await _context.OrderItems.Where(item => item.OrderId == orderId).ToListAsync();

            return order;
        }

        [HttpDelete("RemoveOrder/{orderId}")]
        public async Task<ActionResult<OrderDto>> RemoveById(int orderId)
        {
            if (orderId == 0)
            {
                return BadRequest("Please enter a positive id");
            }

            var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
            {
                return BadRequest("Field with provided id does not exist.");
            }

            order.OrderItems = await _context.OrderItems.Where(item => item.OrderId == order.Id).ToListAsync();

            foreach (var item in order.OrderItems)
            {
                _context.OrderItems.Remove(item);
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            var orderDto = new OrderDto
            {
                AppUserId = order.AppUserId,
                OrderDate = order.OrderDate,
                Status = order.Status,
                TotalAmount = order.TotalAmount

            };

            foreach (var item in order.OrderItems)
            {
                orderDto.OrderItems.Add(new OrderItemDto
                {
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Subtotal = item.Subtotal
                });
            }

            return orderDto;
        }

        [HttpPost("AddOrder/{userId}")]
        public async Task<ActionResult<Order>> AddOrder(int userId, OrderDto orderDto)
        {
            var orderItems = new List<OrderItem>();

            foreach (var item in orderDto.OrderItems)
            {
                orderItems.Add(new OrderItem
                {
                    OrderId = item.OrderId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Subtotal = item.Subtotal
                });
            }

            orderItems.ForEach(item =>
            {
                _context.OrderItems.Add(item);
            });
            // await _context.SaveChangesAsync();

            var order = new Order
            {
                AppUserId = userId,
                OrderDate = orderDto.OrderDate,
                Status = orderDto.Status,
                // OrderItems = orderItems,
                TotalAmount = orderDto.TotalAmount
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return new Order
            {
                AppUserId = order.AppUserId,
                OrderDate = order.OrderDate,
                Id = order.Id,
                OrderItems  = orderItems,
                Status = order.Status,
                TotalAmount = order.TotalAmount
            };
        }
    }
}