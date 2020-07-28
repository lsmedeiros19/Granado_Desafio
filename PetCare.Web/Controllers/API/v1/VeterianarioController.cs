using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;

namespace PetCare.Web.Controllers.API.v1
{
    public class VeterianarioController : BaseAPIController
    {
        private readonly IVeterinarioService _veterianarioService;

        public VeterianarioController(IVeterinarioService veterinarioService)
        {
            _veterianarioService = veterinarioService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVeterinario([FromBody] Veterinario veterinario)
        {
            var vet = await _veterianarioService.CadastrarVeterinario(veterinario);

            return Ok(vet);
        }
    }
}
