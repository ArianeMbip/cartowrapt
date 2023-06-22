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
using static Org.BouncyCastle.Crypto.Fips.FipsKdf;


namespace CartoMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DAsController : ControllerBase
    {
        private readonly DAsService _dAsService;
 

        public DAsController(DAsService dAsService)
        {
            _dAsService = dAsService;
        }

        //[HttpGet("generate")]
        //public IActionResult GeneratePdf()
        //{
        //    string filePath = "path/to/save/pdf.pdf";

        //    await _dAsService.GeneratePdf(filePath);

        //    // Lecture du contenu du fichier PDF généré
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

        //    // Suppression du fichier après la lecture
        //    System.IO.File.Delete(filePath);

        //    // Retourne le fichier PDF en tant que téléchargement
        //    string fileName = "pdf.pdf";
        //    return File(fileBytes, "application/pdf", fileName);
        //}

        [HttpGet]
        [Route("pdf")]
        //public IActionResult GeneratePdf()
        //{
        //    var pdfStream = _dAsService.GeneratePdf();

        //    // Envoi du fichier PDF en tant que réponse HTTP
        //    return File(pdfStream, "application/pdf", "nom_de_votre_fichier.pdf");
        //}

        [HttpGet]
        public async Task<IActionResult> GeneratePdf()
        {
            using (var memoryStream = _dAsService.GeneratePdf())
            {
                // Télécharger le fichier PDF en tant que réponse
                return File(memoryStream.ToArray(), "application/pdf", "nom-du-fichier.pdf");
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> GeneratePdf()
        //{
        //    var memoryStream = _pdfService.GeneratePdf();

        //    // Télécharger le fichier PDF en tant que réponse
        //    return File(memoryStream, "application/pdf", "nom-du-fichier.pdf");
        //}

        //[HttpGet]
        //[Route("pdf")]
        //public async Task<IActionResult> GeneratePdf()
        //{
        //    // Appeler le service pour générer le fichier PDF
        //    var pdfBytes = await _dAsService.GeneratePdf();

        //    // Retourner le fichier PDF en tant que réponse
        //    return File(pdfBytes, "application/pdf", "nom-du-fichier.pdf");
        //}

        //[HttpGet]
        //public async Task<List<DA>> Get() =>
        //    await _dAsService.GetAsync();

        //[HttpGet("{id:length(24)}")]
        //public async Task<ActionResult<DA>> Get(string id)
        //{
        //    var dA = await _dAsService.GetAsync(id);

        //    if (dA is null)
        //    {
        //        return NotFound();
        //    }

        //    return dA;
        //} 

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


