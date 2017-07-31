using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieApps.Models;
using MovieApps.Persistence;
using MovieApps.Controllers.Resources;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MovieApps.Controllers
{
    [Route("/api/vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper mapper;
        private readonly MovieAppsDBContext context;
     
        public VehiclesController(IMapper mapper, MovieAppsDBContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var model = await context.Models.FindAsync(vehicleResource.ModelId);
            if (model == null)
                {
                    ModelState.AddModelError("ModelId", "Invalid modelId");
                    return BadRequest(ModelState);
                }
            var vehicle = mapper.Map<VehicleResource, Vehicle>(vehicleResource);
            vehicle.LastUpdate = DateTime.Now; 
            context.Vehicles.Add(vehicle);
            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleResource vehicleResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var vehicle = await context.Vehicles.Include(v=>v.Features).SingleOrDefaultAsync(v=>v.Id==id);
            mapper.Map<VehicleResource, Vehicle>(vehicleResource, vehicle);
            vehicle.LastUpdate = DateTime.Now; 

            await context.SaveChangesAsync();
            var result = mapper.Map<Vehicle, VehicleResource>(vehicle);
            return Ok(result);
        }        
    }
}