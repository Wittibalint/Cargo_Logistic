using Logistic.Data.Entities;
using Logistic.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistic.API.Controller
{
    [Route("/depot")]
    [ApiController]
    public class DepotController : ControllerBase
    {
        ILogisticService dataService;
        public DepotController(ILogisticService service)
        {
            dataService = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Depot>> GetDepotByIdAsync(int id)
        {
            Depot depot = await dataService.GetDepotByIdAsync(id);
            if (depot != null)
            {
                return Ok(depot);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depot>>> GetDepotAsync(int id)
        {
            List<Depot> depot = (List<Depot>) await dataService.GetDepotsAsync();
            if (depot != null)
            {
                return Ok(depot);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost]
        public async Task<ActionResult<Depot>> PostDepotByIdAsync([FromBody] Depot depot)
        {
            try
            {
                await dataService.InsertOrUpdateDepotAsync(depot);
                return Ok();
            }
            catch
            {
                return NoContent();
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutDepotByIdAsync(int id, [FromBody] Depot depot)
        {
            try
            {
                await dataService.InsertOrUpdateDepotAsync(depot);
                return Ok();
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepotByIdAsync(int id)
        {
            await dataService.DeleteDepotByIdAsync(id);


            return NoContent();
        }
    }
}
