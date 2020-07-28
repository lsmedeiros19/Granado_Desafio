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
    public class AtendimentoController : BaseAPIController
    {
        private readonly IAtendimentoService _atendimentoService;
        private readonly IAnimalService _animalService;

        public AtendimentoController(IAtendimentoService atendimentoService)
        {
            _atendimentoService = atendimentoService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAtendimento([FromBody] Atendimento atendimento)
        {
            try
            {
                await _atendimentoService.CadastrarAtendimento(atendimento);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }