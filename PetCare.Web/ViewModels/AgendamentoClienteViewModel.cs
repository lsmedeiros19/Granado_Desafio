using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Web.ViewModels
{
    public class AgendamentoClienteViewModel
    {
        /// <summary>
        /// Objeto Cliente
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Animal
        /// </summary>
        public Animal Animal { get; set; }

        /// <summary>
        /// Lista de veterinario disponiveis
        /// </summary>
        public List<Veterinario> Veterinarios { get; set; }
    }
}
