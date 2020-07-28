using System;
using System.Collections.Generic;
using System.Text;

namespace PetCare.Domain.Dto
{
    public class AgendaDisponivelDTO
    {
        /// <summary>
        /// 
        /// </summary>
        public string Veterinario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdVeterinario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<string> HorariosDisponiveis { get; set; }
    }
}
