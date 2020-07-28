using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Web.ViewModels
{
    public class ClienteAnimalVieModel 
    {
        /// <summary>
        /// Objeto Cliente
        /// </summary>
        public Cliente Cliente { get; set; }

        /// <summary>
        /// Listra de Animais
        /// </summary>
        public List<Animal> Animais { get; set; }
    }
}
