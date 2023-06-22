using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartoMongo.Models;
using CartoMongo.Services;
using MongoDB.Bson;
using System.Net;

namespace CartoMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeElementsController : ControllerBase
    {
        private readonly TypeElementsService _typeElementsService;

        public TypeElementsController(TypeElementsService typeElementsService) =>
            _typeElementsService = typeElementsService;

        
        [HttpGet]
        public async Task<List<TypeElement>> Get() =>
            await _typeElementsService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<TypeElement>> Get(string id)
        {
            var typeElement = await _typeElementsService.GetAsync(id);

            if (typeElement is null)
            {
                return NotFound();
            }

            return typeElement;
        }

        [HttpPost]
        public async Task<IActionResult> Post(TypeElement newTypeElement)
        {
            await _typeElementsService.CreateAsync(newTypeElement);

            return CreatedAtAction(nameof(Get), new { id = newTypeElement.Id }, newTypeElement);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, TypeElement updatedTypeElement)
        {
            var typeElement = await _typeElementsService.GetAsync(id);

            if (typeElement is null)
            {
                return NotFound();
            }

            updatedTypeElement.Id = typeElement.Id;

            await _typeElementsService.UpdateAsync(id, updatedTypeElement);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var typeElement = await _typeElementsService.GetAsync(id);

            if (typeElement is null)
            {
                return NotFound();
            }

            await _typeElementsService.RemoveAsync(id);

            return NoContent();
        }

    }
}

