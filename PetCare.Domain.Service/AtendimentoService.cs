using PetCare.Domain.Dto;
using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Domain.Service
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IAtendimentoRepository _atendimentoRepository;
        private readonly IVeterinarioRepository _veterinarioRepository;

        public AtendimentoService(IAtendimentoRepository atendimentoRepository,
            IVeterinarioRepository veterinarioRepository)
        {
            _atendimentoRepository = atendimentoRepository;
            _veterinarioRepository = veterinarioRepository;
        }

        public void CadastrarAtendimento(Atendimento atendimento)
        {
            if (atendimento != null)
                _atendimentoRepository.InsertAsync(atendimento);
        }

        public async Task<Atendimento> ObterAtendimentoPorIdAsync(int id)
        {
            Atendimento atendimento = new Atendimento();
            if (id != 0)
                atendimento = await _atendimentoRepository.GetFirstAsync(x => x.Id == id);

            return atendimento;
        }

        public async Task<IList<HistoricoAtendimentoDto>> ObterHistoricoAtendimentoDoAnimalAsync(int idAnimal)
        {

            IList<HistoricoAtendimentoDto> historicoAtendimentoDtos = new List<HistoricoAtendimentoDto>();

            var atendimentos = await _atendimentoRepository.GetAsync(x => x.IdAnimal == idAnimal);

            foreach (var item in atendimentos)
            {
                var vet = await _veterinarioRepository.GetFirstAsync(x => x.Id == item.IdVeterinario);

                var historico = new HistoricoAtendimentoDto() { Atendimento = item,
                    Veterinario = vet
                };
                historicoAtendimentoDtos.Add(historico);
            }

            return historicoAtendimentoDtos;
        }
    }
}
