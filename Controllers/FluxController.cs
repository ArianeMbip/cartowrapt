using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartoMongo.Models;
using CartoMongo.Services;
using MongoDB.Driver;
using MongoDB.Bson;

namespace CartoMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FluxController : ControllerBase
    {
        private readonly FluxService _fluxService;

        public FluxController(FluxService fluxService) =>
            _fluxService = fluxService;

        [HttpGet]
        public async Task<List<Flux>> Get() =>
            await _fluxService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Flux>> Get(string id)
        {
            var flux = await _fluxService.GetAsync(id);

            if (flux is null)
            {
                return NotFound();
            }

            return flux;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Flux newFlux)
        {
            await _fluxService.CreateAsync(newFlux);

            return CreatedAtAction(nameof(Get), new { id = newFlux.Id }, newFlux);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Flux updatedFlux)
        {
            var flux = await _fluxService.GetAsync(id);

            if (flux is null)
            {
                return NotFound();
            }

            updatedFlux.Id = flux.Id;

            await _fluxService.UpdateAsync(id, updatedFlux);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var flux = await _fluxService.GetAsync(id);

            if (flux is null)
            {
                return NotFound();
            }

            await _fluxService.RemoveAsync(id);

            return NoContent();
        }

    }
}
