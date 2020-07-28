using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetCare.Domain.Dto
{
    public class AgendaVeterianarioDto
    {
        public Veterinario Veterianario { get; set; }

        public IList<string> HorariosDiponiveis { get; set; }

        public string Dia { get; set; }


    }
}
