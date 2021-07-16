using Logistic.API.Service;
using Logistic.data.Model;
using Logistic.Data.Entities;
using Logistic.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistic.API.Controller
{
    [Route("/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        ILogisticService dataService;
        EmailSender email;
        public OrderController(ILogisticService service, EmailSender emailSender)
        {
            dataService = service;
            email = emailSender;
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderByIdAsync(int id)
        {
            Order Order = await dataService.GetOrderByIdAsync(id);
            if (Order != null)
            {
                return Ok(Order);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderWithEmail>>> GetOrderAsync()
        {
            List<OrderWithEmail> ordersWithEmail = (List<OrderWithEmail>)await dataService.GetOrdersWithEmailAsync();

            if (ordersWithEmail != null)
            {
                return Ok(ordersWithEmail);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("/order/date")]
        public async Task<ActionResult<IEnumerable<OrderWithEmail>>> GetOorderByDateAsync([FromQuery]DateTime date)
        {
            List<OrderWithEmail> ordersWithEmail = (List<OrderWithEmail>)await dataService.GetOrdersWithEmailByDateAsync(date);

            if (ordersWithEmail != null)
            {
                return Ok(ordersWithEmail);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("/order/date/delivered")]
        public async Task<ActionResult<IEnumerable<OrderWithEmail>>> GetOrderByDateDeliveredAsync([FromQuery] DateTime date)
        {
            List<OrderWithEmail> ordersWithEmail = (List<OrderWithEmail>)await dataService.GetOrdersWithEmailByDateDeliveredAsync(date);

            if (ordersWithEmail != null)
            {
                return Ok(ordersWithEmail);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet("/order/user/{id}")]
        public async Task<ActionResult<IEnumerable<OrderWithEmail>>> GetOrderByUseridAsync(int id)
        {
            List<Order> orders = (List<Order>) await dataService.GetOrdersByUserIdAsync(id);

            if (orders != null)
            {
                return Ok(orders);
            }
            else
            {
                return NoContent();
            }
        }


        [HttpPost]
        public async Task<ActionResult<User>> PostOrderByIdAsync([FromBody] Order order)
        {

            await dataService.InsertOrUpdateOrderAsync(order);
            User user = await dataService.GetUserByIdAsync(order.UserId);
            List<Order> orderNew = (List<Order>) await dataService.GetOrdersByUserIdAsync(order.UserId);
            await email.SendEmailAsync(user.Email, "Megrendelés", "Köszönjük megrendelését!\n\n"+ "Megrendelésének azonosítója: "+orderNew.Select(o=>o).OrderBy(o=>o.RegistryDate).Last().Id.ToString());
            return Ok();

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUserByIdAsync(int id, [FromBody] Order order)
        {
            try
            {
                await dataService.InsertOrUpdateOrderAsync(order);
                return Ok();
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderByIdAsync(int id)
        {
            await dataService.DeleteOrderByIdAsync(id);


            return NoContent();
        }
    }
}
