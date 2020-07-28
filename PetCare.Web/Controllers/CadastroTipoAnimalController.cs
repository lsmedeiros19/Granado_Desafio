using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetCare.Domain.Service.Abstraction;

namespace PetCare.Web.Controllers
{
    public class CadastroTipoAnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public CadastroTipoAnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        //public async Task<IActionResult> IndexAsync()
        //{
        //    var cliente = await

        //    _clienteService.ObterClientePorCpfAsync("10136837735");

        //    return View();
        //}
    }
}