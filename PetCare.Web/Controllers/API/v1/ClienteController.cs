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
    public class ClienteController : BaseAPIController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarCliente([FromBody] Cliente cliente)
        {
            Cliente clienteCriado = new Cliente();

            //Verificar CPF existente
            var Cli = await _clienteService.ObterClientePorCpfAsync(cliente.Cpf);

            if (Cli == null)
            {
                clienteCriado = await _clienteService.CadastrarCliente(cliente);
                return CreatedAtRoute(nameof(ObterClientePorId), new { id = clienteCriado.Id }, clienteCriado);
            }
            else
            {
                return BadRequest("Cliente Existente");
            }
        }

        [HttpGet("{id}", Name = nameof(ObterClientePorId))]
        public async Task<IActionResult> ObterClientePorId([FromRoute]int id)
        {
            var cliente = await _clienteService.ObterClientePorIdAsync(id);

            return Ok(cliente);
           
        }

        [HttpGet]
        public async Task<IActionResult> ObterClientePorCpf([FromQuery] string cpf)
        {
            var cliente = await _clienteService.ObterClientePorCpfAsync(cpf);

            return Ok(cliente);

        }
    }
}
