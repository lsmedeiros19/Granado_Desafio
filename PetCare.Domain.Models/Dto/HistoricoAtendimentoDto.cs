using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetCare.Domain.Dto
{
    public class HistoricoAtendimentoDto
    {
        public Veterinario Veterinario { get; set; }

        public Atendimento Atendimento { get; set; }
    }
}
