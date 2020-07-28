using PetCare.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Web.ViewModels
{
    public class HistoricoAtendimentoViewModel
    {
        public string NomeAnimal { get; set; }

        public IList<HistoricoAtendimentoDto> Historico { get; set; }
    }
}
