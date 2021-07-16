using Logistic.Data.Entities;
using Logistic.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logistic.API.Controller
{
    [Route("/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        ILogisticService dataService;
        public VehicleController(ILogisticService service)
        {
            dataService = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Vehicle>> GetVehiclesByIdAsync(int id)
        {
            Vehicle vehicle = await dataService.GetVehicleByIdAsync(id);
            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            else
            {
                return NoContent();
            }
        }
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicleAsync()
        {
            List<Vehicle> vehicle = (List<Vehicle>)await dataService.GetVehiclesAsync();
            if (vehicle != null)
            {
                return Ok(vehicle);
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPost]
        public async Task<ActionResult<Vehicle>> PostVehicleByIdAsync([FromBody] Vehicle vehicle)
        {
            try
            {
                await dataService.InsertOrUpdateVehicleAsync(vehicle);
                return Ok();
            }
            catch
            {
                return NoContent();
            }

        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Vehicle>> PutVehicleByIdAsync(int id, [FromBody] Vehicle vehicle)
        {
            try
            {
                await dataService.InsertOrUpdateVehicleAsync(vehicle);
                return Ok();
            }
            catch
            {
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteVehicleByIdAsync(int id)
        {
            await dataService.DeleteVehicleByIdAsync(id);


            return NoContent();
        }
    }
}
