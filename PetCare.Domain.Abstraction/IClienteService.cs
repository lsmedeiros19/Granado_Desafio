using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Domain.Service.Abstraction
{
    public interface IClienteService
    {
        Task<Cliente> CadastrarCliente(Cliente cliente);

        Task<Cliente> ObterClientePorCpfAsync(string cpf);

        Task<Cliente> ObterClientePorIdAsync(int id);

    }
}
