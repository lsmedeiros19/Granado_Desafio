using PetCare.Domain.Dto;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Domain.Service.Abstraction
{
    public interface IAgendamentoService
    {
        Task CadastrarAgendamento(Agendamento agendamento);

        Task<IList<AgendaMarcadaDto>> ListarAgendamentoDoDiaAsync(DateTime? dataAgendamento);

        Task<IList<AgendaVeterianarioDto>> CarregarListaVetDisponivelAsync(Animal animal, DateTime? dataAgendamento = null, int? idVeterinario = null);
    }
}
