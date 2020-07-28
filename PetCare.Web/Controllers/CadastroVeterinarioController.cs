using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;

namespace PetCare.Web.Controllers
{
    public class CadastroVeterinarioController : Controller
    {
        private readonly IVeterinarioService _veterinarioService;

        public CadastroVeterinarioController(IVeterinarioService veterinarioService)
        {
            _veterinarioService = veterinarioService;
        }

        public async Task<IActionResult> Index()
        {
            IList<Veterinario> lista = new List<Veterinario>();

            lista = await _veterinarioService.ListaVeterinarioAsync();

            return View(lista);
        }
    }
}
