using System;
using System.Collections.Generic;
using System.Text;

namespace PetCare.Domain.Dto
{
    public class AgendaMarcadaDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string NomeCliente { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NomeAnimal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TipoAnimal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DataAtendimento { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int IdVeterinario { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NomeVeterinario { get; set; }
    }
}
