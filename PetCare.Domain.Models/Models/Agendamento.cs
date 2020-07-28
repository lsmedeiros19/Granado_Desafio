using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Agendamento : IEntidade
    {
        /// <summary>
        /// Id do Agendamento
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
        /// Data da Consulta
        /// </summary>
        public DateTime DataConsulta { get; set; }

        /// <summary>
        /// Data do Cadastro da Consulta
        /// </summary>
        public DateTime DataCadastro { get; set; }

    }
}