using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Domain.Service
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public void AlterarAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public async Task CadastrarAnimaisAsync(List<Animal> animais)
        {
            if (animais != null)
            {
                foreach (var item in animais)
                {
                    //if(item.Nome == "")

                    //if(item.Idade == null)

                    //if (item.Tipo == null)
                
                    item.DataCadastro = DateTime.Now;
                  var idAnimal = await  _animalRepository.InsertAsync(item);
                }
            }
        }

        public async Task<Animal> ObterAnimalPorIdAsync(int IdAnimal)
        {
            Animal animal = new Animal();

            if (IdAnimal != 0)
                animal = await _animalRepository.GetFirstAsync(x => x.Id == IdAnimal);
            else
                throw new Exception("Não foi passado Id Animal");

            return animal;
        }

        public async Task<IList<Animal>> ObterAnimalPorIdClienteAsync(int id)
        {
            IList<Animal> listaAnimais = new List<Animal>();

            if (id != 0)
                listaAnimais = await _animalRepository.GetAsync(x => x.IdCliente == id);

            return listaAnimais;
        }

    }
}
