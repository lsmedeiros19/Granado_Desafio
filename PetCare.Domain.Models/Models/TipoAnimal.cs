using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class TipoAnimal : IEntidade
    {
        /// <summary>
        /// Id Tipo Animal
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do tipo Animal
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Data de Cadastro
        /// </summary>
        public DateTime DataCadastro { get; set; }

    }
}