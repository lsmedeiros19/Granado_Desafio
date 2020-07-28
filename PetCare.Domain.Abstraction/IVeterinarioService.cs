using PetCare.Domain.Dto;
using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Domain.Service.Abstraction
{
    public interface IVeterinarioService
    {
        Task<Veterinario> CadastrarVeterinario(Veterinario veterinario);

        Task<IList<Veterinario>> ListaVeterinarioAsync();

        Task<Veterinario> ObterVeterinarioPorId(int id);

        Task<IList<Veterinario>> ObterVeterinarioPeloIdAnimalAsync(int idAnimal);

        Task ExcluirVeterinarioAsync(int id);
    }
}
