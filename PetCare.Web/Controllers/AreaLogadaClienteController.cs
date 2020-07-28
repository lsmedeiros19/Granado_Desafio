//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AspNetCore;
//using Microsoft.AspNetCore.Components.Forms;
//using Microsoft.AspNetCore.Mvc;
//using PetCare.Domain.Models;
//using PetCare.Domain.Service.Abstraction;
//using PetCare.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Service.Abstraction;
using PetCare.Web.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Web.Controllers
{
    public class AreaLogadaClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IAnimalService _animalService;

        public AreaLogadaClienteController(IClienteService clienteService, IAnimalService animalService)
        {
            _clienteService = clienteService;
            _animalService = animalService;
        }

        public async Task<IActionResult> Inicio(int id)
        {
            ClienteAnimalVieModel clienteAnimal = new ClienteAnimalVieModel();

            var cliente = await _clienteService.ObterClientePorIdAsync(id);

            var animais = await _animalService.ObterAnimalPorIdClienteAsync(cliente.Id);

            clienteAnimal.Cliente = cliente;
            clienteAnimal.Animais = animais.ToList();

            return View(clienteAnimal);
        }

    }
}
