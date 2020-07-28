using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Domain.Service.Abstraction
{
    public interface IAtendimentoService
    {
        Task CadastrarAtendimento(Atendimento atendimento);

        Task<Atendimento> ObterAtendimentoPorIdAsync(int id);

        Task<IList<Dto.HistoricoAtendimentoDto>> ObterHistoricoAtendimentoDoAnimalAsync(int idAnimal);
    }
}
