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
using System.Net;

namespace CartoMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActifsController : ControllerBase
    {
        private readonly ActifsService _actifsService;
        private readonly TypeElementsService _typeElementsService;

        public ActifsController(ActifsService actifsService, TypeElementsService typeElementsService)
        {
            _actifsService = actifsService;
            _typeElementsService = typeElementsService;
        }

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
            // Récupérez l'identifiant du type d'actif spécifié dans le corps de la requête
            //string typeActifId = newActif.TypeActif.Id;

            // Récupérez l'instance correspondante de la classe TypeActif à partir de l'identifiant
            //TypeElement typeActif = await _typeElementsService.GetAsync(typeActifId);

            // Récupérer les informations du type d'actif correspondant
            var typeActif = await _typeElementsService.GetAsync(newActif.TypeActif.Id);

            if (typeActif == null)
            {
                return NotFound("Le type d'actif spécifié est introuvable.");
            }

            // Associer les informations du type d'actif à l'actif nouvellement créé   
            newActif.TypeActif = typeActif;

            // Appeler la méthode de création de l'actif dans le service ActifsService
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
