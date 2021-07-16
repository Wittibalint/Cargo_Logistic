using Logistic.Data.Entities;
using Logistic.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistic.API.Controller
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ILogisticService dataService;
        public UserController(ILogisticService service)
        {
            dataService = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            User user = await dataService.GetUserByIdAsync(id);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost]
        public async Task<ActionResult<User>> PostUserByIdAsync([FromBody] User user)
        {
            try
            {
                await dataService.InsertOrUpdateUserAsync(user);
                return Ok();
            }
            catch
            {
                return NoContent();
            }
                
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUserByIdAsync(int id, [FromBody] User user)
        {
            try
            {
                await dataService.InsertOrUpdateUserAsync(user);
                return Ok();
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserByIdAsync(int id)
        {
            await dataService.DeleteUserByIdAsync(id);


            return NoContent();
        }
    }
}
