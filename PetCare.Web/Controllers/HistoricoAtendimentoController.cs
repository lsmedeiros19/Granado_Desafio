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
    public class HistoricoAtendimentoController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly IAtendimentoService _atendimentoService;

        public HistoricoAtendimentoController(
            IAnimalService animalService,
            IAtendimentoService atendimentoService)
        {
            _animalService = animalService;
            _atendimentoService = atendimentoService;
        }

        public async Task<IActionResult> Index(int id)
        {
            HistoricoAtendimentoViewModel historicoAtendimentoView   = new HistoricoAtendimentoViewModel();

            var animal = await _animalService.ObterAnimalPorIdAsync(id);

            var historico = await _atendimentoService.ObterHistoricoAtendimentoDoAnimalAsync(id);

            historicoAtendimentoView.NomeAnimal = animal.Nome;
            historicoAtendimentoView.Historico = historico;

            return View(historicoAtendimentoView);
        }
    }
}
