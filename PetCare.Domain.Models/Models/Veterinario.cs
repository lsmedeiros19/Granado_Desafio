using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Veterinario : IEntidade
    {
        /// <summary>
        /// Id do Veterinário
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do Veterinário
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Especialidade de Geriatria
        /// </summary>
        public bool Geriatra { get; set; }

        /// <summary>
        /// Data da Contratação
        /// </summary>
        public DateTime DataContratacao { get; set; }

        /// <summary>
        /// Data do Cadastro
        /// </summary>
        public DateTime DataCadastro { get; set; }
    }
}