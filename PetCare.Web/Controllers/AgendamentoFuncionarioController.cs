using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;

namespace PetCare.Web.Controllers
{
    public class AgendamentoFuncionarioController : Controller
    {
        private readonly IAgendamentoService _agendamentoService;
        private readonly IVeterinarioService _veterinarioService;

        public AgendamentoFuncionarioController(IAgendamentoService agendamentoService, IVeterinarioService veterinarioService)
        {
            _agendamentoService = agendamentoService;
            _veterinarioService = veterinarioService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            IList<Veterinario> lista = new List<Veterinario>();

            lista = await _veterinarioService.ListaVeterinarioAsync();

            return View(lista);
        }
    }
}
