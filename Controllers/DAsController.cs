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
    public class DAsController : ControllerBase
    {
        private readonly DAsService _dAsService;

        public DAsController(DAsService dAsService) =>
            _dAsService = dAsService;

        [HttpGet]
        public async Task<List<DA>> Get() =>
            await _dAsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<DA>> Get(string id)
        {
            var dA = await _dAsService.GetAsync(id);

            if (dA is null)
            {
                return NotFound();
            }

            return dA;
        } 

        // [HttpPost]
        //public async Task<IActionResult> Post(DA newDA)
        //{
        //    await _dAsService.CreateAsync(newDA);

        //    return CreatedAtAction(nameof(Get), new { id = newDA.Id }, newDA);
        //}

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, DA updatedDA)
        {
            var dA = await _dAsService.GetAsync(id);

            if (dA is null)
            {
                return NotFound();
            }

            updatedDA.Id = dA.Id;

            await _dAsService.UpdateAsync(id, updatedDA);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var dA = await _dAsService.GetAsync(id);

            if (dA is null)
            {
                return NotFound();
            }

            await _dAsService.RemoveAsync(id);

            return NoContent();
        }

    }
}
