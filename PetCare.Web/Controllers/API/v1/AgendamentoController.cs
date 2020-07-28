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
    public class AgendamentoController : BaseAPIController
    {
        private readonly IAgendamentoService _agendamentoService;
        private readonly IAnimalService _animalService;

        public AgendamentoController(IAgendamentoService agendamentoService, IAnimalService animalService)
        {
            _agendamentoService = agendamentoService;
            _animalService = animalService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAgendamento([FromBody] Agendamento agendamento)
        {
            try
            {
                await _agendamentoService.CadastrarAgendamento(agendamento);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConsultaAgendaDisponivel(int idAnimal, DateTime? dataAgendamento, int? idVeterinario)
        {
            var animal = await _animalService.ObterAnimalPorIdAsync(idAnimal);

            var listaVetDisnivel = await _agendamentoService.CarregarListaVetDisponivelAsync(animal, dataAgendamento, idVeterinario);

            return Ok(listaVetDisnivel);
        }

        [HttpGet("marcados")]
        public async Task<IActionResult> ConsultaAgendamentosMarcados(DateTime? dataAgendamento)
        {
            var listaAgendaMarcados = await _agendamentoService.ListarAgendamentoDoDiaAsync(dataAgendamento);

            return Ok(listaAgendaMarcados);
        }
    }
}
