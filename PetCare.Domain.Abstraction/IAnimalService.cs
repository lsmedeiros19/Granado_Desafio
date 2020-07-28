using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Domain.Service.Abstraction
{
    public interface IAnimalService
    {
        Task CadastrarAnimaisAsync(List<Animal> animais);

        void AlterarAnimal(Animal animal);

        Task<IList<Animal>> ObterAnimalPorIdClienteAsync(int id);

        Task<Animal> ObterAnimalPorIdAsync(int IdAnimal);

    }
}
