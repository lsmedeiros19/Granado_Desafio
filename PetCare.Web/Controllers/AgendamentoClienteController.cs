using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;
using PetCare.Web.ViewModels;

namespace PetCare.Web.Controllers
{
    public class AgendamentoClienteController : Controller
    {
        private readonly IAgendamentoService _agendamentoService;
        private readonly IClienteService _clienteService;
        private readonly IAnimalService _animalService;
        private readonly IVeterinarioService _veterinarioService;

        public AgendamentoClienteController(IAgendamentoService agendamentoService,
            IClienteService clienteService,
            IAnimalService animalService,
            IVeterinarioService veterinarioService)
        {
            _agendamentoService = agendamentoService;
            _clienteService = clienteService;
            _animalService = animalService;
            _veterinarioService = veterinarioService;
        }

        public async Task<IActionResult> Index(int id)
        {
            AgendamentoClienteViewModel agendamentoCliente = new AgendamentoClienteViewModel();

            var animal = await _animalService.ObterAnimalPorIdAsync(id);

            var cliente = await _clienteService.ObterClientePorIdAsync(animal.IdCliente);

            var veterinarios = await _veterinarioService.ObterVeterinarioPeloIdAnimalAsync(id);

            agendamentoCliente.Veterinarios = veterinarios.ToList();
            agendamentoCliente.Cliente = cliente;
            agendamentoCliente.Animal = animal;

            return View(agendamentoCliente);
        }
    }
}
