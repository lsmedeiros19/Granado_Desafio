

using PetCare.Domain.Dto;
using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace PetCare.Domain.Service
{
    public class VeterinarioService : IVeterinarioService
    {
        private readonly IVeterinarioRepository _veterinarioRepository;
        private readonly IAnimalRepository _animalRepository;

        public VeterinarioService(IVeterinarioRepository veterinarioRepository,
                                  IAnimalRepository animalRepository)
        {
            _veterinarioRepository = veterinarioRepository;
            _animalRepository = animalRepository;
        }


        public async Task<Veterinario> CadastrarVeterinario(Veterinario veterinario)
        {
            if (veterinario != null)
            {
                //Tratamento de Erro dos campos Obrigatórios
                //if (veterinario.Nome == "")

                //if (veterinario.DataContratacao == null)

                veterinario.DataContratacao = DateTime.Now;
                veterinario.DataCadastro = DateTime.Now;
                await _veterinarioRepository.InsertAsync(veterinario);
            }
            return veterinario;
        }

        public IList<AgendaDisponivelDTO> ListarVeterinarioDisponivel()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Veterinario>> ListaVeterinarioAsync()
        {
            IList<Veterinario> lista = new List<Veterinario>();

            lista = await _veterinarioRepository.GetAsync();

            return lista;
        }

        public async Task<IList<Veterinario>> ObterVeterinarioPeloIdAnimalAsync(int idAnimal)
        {
            var animal = await _animalRepository.GetFirstAsync(x => x.Id == idAnimal);

            if (animal.IsIdoso)
                return await _veterinarioRepository.GetAsync(x => x.Geriatra);


            return await _veterinarioRepository.GetAsync();
        }

        public async Task<Veterinario> ObterVeterinarioPorId(int id)
        {
            Veterinario veterinario = new Veterinario();
            if (id != 0)
                veterinario = await _veterinarioRepository.GetFirstAsync(x => x.Id == id);

            return veterinario;
        }
    }
}
