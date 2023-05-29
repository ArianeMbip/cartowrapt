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
    public class ActifsController : ControllerBase
    {
        private readonly ActifsService _actifsService;

        public ActifsController(ActifsService actifsService) =>
            _actifsService = actifsService;

        [HttpGet]
        public async Task<List<Actif>> Get() =>
            await _actifsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Actif>> Get(string id)
        {
            var actif = await _actifsService.GetAsync(id);

            if (actif is null)
            {
                return NotFound();
            }

            return actif;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Actif newActif)
        {
            await _actifsService.CreateAsync(newActif);

            return CreatedAtAction(nameof(Get), new { id = newActif.Id }, newActif);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Actif updatedActif)
        {
            var actif = await _actifsService.GetAsync(id);

            if (actif is null)
            {
                return NotFound();
            }

            updatedActif.Id = actif.Id;

            await _actifsService.UpdateAsync(id, updatedActif);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var actif = await _actifsService.GetAsync(id);

            if (actif is null)
            {
                return NotFound();
            }

            await _actifsService.RemoveAsync(id);

            return NoContent();
        }

    }
}
