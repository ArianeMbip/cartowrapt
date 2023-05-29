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
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Drawing;

namespace CartoMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IconesController : ControllerBase
    {
        private readonly IconesService _iconesService;

        public IconesController(IconesService iconesService) =>
            _iconesService = iconesService;

        [HttpGet]
        public async Task<List<Icone>> Get() =>
            await _iconesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Icone>> Get(string id)
        {
            var icone = await _iconesService.GetAsync(id);

            if (icone is null)
            {
                return NotFound();
            }

            return icone;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Icone newIcone)
        {
            await _iconesService.CreateAsync(newIcone);

            return CreatedAtAction(nameof(Get), new { id = newIcone.Id }, newIcone);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Icone updatedIcone)
        {
            var icone = await _iconesService.GetAsync(id);

            if (icone is null)
            {
                return NotFound();
            }

            updatedIcone.Id = icone.Id;

            await _iconesService.UpdateAsync(id, updatedIcone);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var icone = await _iconesService.GetAsync(id);

            if (icone is null)
            {
                return NotFound();
            }

            await _iconesService.RemoveAsync(id);

            return NoContent();
        }

    }
}
