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

        public AtendimentoService(IAtendimentoRepository atendimentoRepository)
        {
            _atendimentoRepository = atendimentoRepository;
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
    }
}
