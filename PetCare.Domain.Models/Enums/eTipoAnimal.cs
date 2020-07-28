using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PetCare.Domain.Enums
{
    public enum eTipoAnimal : int
    {
        [Description("Cachorro")]
        Cachorro = 1,
        [Description("Gato")]
        Gato = 2,
        [Description("Hamster")]
        Hamster = 3
    }
}
