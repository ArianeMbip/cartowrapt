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
using System.Data;

namespace CartoMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RolesService _rolesService;

        public RolesController(RolesService rolesService) =>
            _rolesService = rolesService;

        [HttpGet]
        public async Task<List<Role>> Get() =>
            await _rolesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Role>> Get(string id)
        {
            var role = await _rolesService.GetAsync(id);

            if (role is null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Role newRole)
        {
            await _rolesService.CreateAsync(newRole);

            return CreatedAtAction(nameof(Get), new { id = newRole.Id }, newRole);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Role updatedRole)
        {
            var role = await _rolesService.GetAsync(id);

            if (role is null)
            {
                return NotFound();
            }

            updatedRole.Id = role.Id;

            await _rolesService.UpdateAsync(id, updatedRole);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _rolesService.GetAsync(id);

            if (role is null)
            {
                return NotFound();
            }

            await _rolesService.RemoveAsync(id);

            return NoContent();
        }

    }
}
