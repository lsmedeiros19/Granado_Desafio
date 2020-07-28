using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Cliente : IEntidade
    {
        /// <summary>
        /// Id do Cliente
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do Cliente
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// CPF do Cliente
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Data do Cadastro
        /// </summary>
        public DateTime DataCadastro { get; set; }
    }
}