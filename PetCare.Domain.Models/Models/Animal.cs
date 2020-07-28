using PetCare.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Models
{
    public class Animal : IEntidade
    {
        /// <summary>
        /// Id do Animal
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id do Cliente
        /// </summary>
        public int IdCliente { get; set; }

        /// <summary>
        /// Nome do Animal
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Idade do Animal
        /// </summary>
        public int Idade { get; set; }

        /// <summary>
        /// Data de Cadastro do Animal
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Tipo de Animal
        /// </summary>
        public eTipoAnimal Tipo { get; set; }


        public bool IsIdoso
        {
            get
            {
                bool valor;
                switch (Tipo)
                {
                    case eTipoAnimal.Hamster:
                        valor = Idade > 2;
                        break;

                    default:
                        valor = Idade > 7;
                        break;
                }
                return valor;
            }
        }
    }
}