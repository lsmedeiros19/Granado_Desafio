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
        //void CadastrarVeterinario(Veterinario veterinario);
        Task<Veterinario> CadastrarVeterinario(Veterinario veterinario);

        IList<AgendaDisponivelDTO> ListarVeterinarioDisponivel();

        Task<IList<Veterinario>> ListaVeterinarioAsync();

        Task<Veterinario> ObterVeterinarioPorId(int id);

        Task<IList<Veterinario>> ObterVeterinarioPeloIdAnimalAsync(int idAnimal);
    }
}
