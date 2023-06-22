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
using Microsoft.Extensions.Hosting;

namespace CartoMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironnementsController : ControllerBase
    {
        private readonly EnvironnementsService _environnementsService;

        public EnvironnementsController(EnvironnementsService environnementsService) =>
            _environnementsService = environnementsService;

        [HttpGet]
        public async Task<List<Environnement>> Get() =>
            await _environnementsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Environnement>> Get(string id)
        {
            var environnement = await _environnementsService.GetAsync(id);

            if (environnement is null)
            {
                return NotFound();
            }

            return environnement;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Environnement newEnvironnement)
        {
            await _environnementsService.CreateAsync(newEnvironnement);

            return CreatedAtAction(nameof(Get), new { id = newEnvironnement.Id }, newEnvironnement);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Environnement updatedEnvironnement)
        {
            var environnement = await _environnementsService.GetAsync(id);

            if (environnement is null)
            {
                return NotFound();
            }

            updatedEnvironnement.Id = environnement.Id;

            await _environnementsService.UpdateAsync(id, updatedEnvironnement);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var environnement = await _environnementsService.GetAsync(id);

            if (environnement is null)
            {
                return NotFound();
            }

            await _environnementsService.RemoveAsync(id);

            return NoContent();
        }

    }
}
