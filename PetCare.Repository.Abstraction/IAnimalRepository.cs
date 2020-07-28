using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetCare.Repository.Abstraction
{
    public interface IAnimalRepository : IGenericRepository<Animal>
    {
    }
}
