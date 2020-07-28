using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Domain.Service
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> CadastrarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                cliente.Cpf = cliente.Cpf.Trim().Replace(".", "").Replace("-", "");

                if (!Utils.ValidaCPF.IsCpf(cliente.Cpf))
                    throw new Exception("Cpf inválido");

                if (cliente.Nome.Trim() == "")
                    throw new Exception("O nome é obrigatório");

                if ((await _clienteRepository.GetFirstAsync(x => cliente.Cpf.Trim() == x.Cpf.Trim())) != null)
                    throw new Exception("Cpf já cadastrado");
                

                cliente.DataCadastro = DateTime.Now;

                var id = await _clienteRepository.InsertAsync(cliente);

                var clienteCriado = await ObterClientePorIdAsync(id);

                return clienteCriado;
            }
            return cliente;
        }

        public async Task<Cliente> ObterClientePorCpfAsync(string cpf)
        {
            Cliente cliente = new Cliente();
            if (cpf != "")
                cliente = await _clienteRepository.GetFirstAsync(x => x.Cpf == cpf);

            return cliente;
        }

        public async Task<Cliente> ObterClientePorIdAsync(int id)
        {
            Cliente cliente = new Cliente();
            if (id != 0)
                cliente = await _clienteRepository.GetFirstAsync(x => x.Id == id);

            return cliente;
        }

    }
}
