using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Atendimento : IEntidade
    {
        /// <summary>
        /// Id do Atendimento
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id do Veterinário
        /// </summary>
        public int IdVeterinario { get; set; }

        /// <summary>
        /// Id do Animal
        /// </summary>
        public int IdAnimal { get; set; }

        /// <summary>
        /// Diagnóstico do Atendimento
        /// </summary>
        public string Diagnostico { get; set; }

        /// <summary>
        /// Data do Atendimento
        /// </summary>
        public DateTime DataAtendimento { get; set; }

        /// <summary>
        /// Data do Cadastro do Atendimento
        /// </summary>
        public DateTime DataCadastro { get; set; }

    }
}