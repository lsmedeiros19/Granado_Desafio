using PetCare.Domain.Dto;
using PetCare.Domain.Models;
using PetCare.Domain.Service.Abstraction;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PetCare.Domain.Service
{
    public class AgendamentoService : IAgendamentoService
    {
        public readonly IAgendamentoRepository _agendamentoRepository;
        public readonly IVeterinarioRepository _veterinarioRepository;
        public readonly IAnimalRepository _animalRepository;
        public readonly IClienteRepository _clientesRepository;

        public AgendamentoService(IAgendamentoRepository agendamentoRepository, IVeterinarioRepository veterinarioRepository, IAnimalRepository animalRepository, IClienteRepository clienteRepository)
        {
            _agendamentoRepository = agendamentoRepository;
            _veterinarioRepository = veterinarioRepository;
            _animalRepository = animalRepository;
            _clientesRepository = clienteRepository;
        }

        public void CadastrarAgendamento(Agendamento agendamento)
        {
            if (agendamento != null)
            {
                //if (agendamento.IdAnimal == null)
                //    throw new Exception("mensagem");

                //if (agendamento.IdVeterinario == null)

                agendamento.DataCadastro = DateTime.Now;

                _agendamentoRepository.InsertAsync(agendamento);
            }
        }

        public async Task<IList<AgendaMarcadaDto>> ListarAgendamentoDoDiaAsync(DateTime? dataAgendamento)
        {
            IList<AgendaMarcadaDto> listaDia = new List<AgendaMarcadaDto>();

            DateTime dataConsulta = dataAgendamento.HasValue ? dataAgendamento.Value : DateTime.Now;

            var agendaDia = await _agendamentoRepository.GetAsync(x => x.DataConsulta.Date == dataConsulta.Date);

            var idVeterionarios = agendaDia.Select(x => x.IdVeterinario).Distinct();

            var idAnimais = agendaDia.Select(x => x.IdAnimal).Distinct();

            var veterinarios = await _veterinarioRepository.GetAsync(x => idVeterionarios.Contains(x.Id));

            var animais = await _animalRepository.GetAsync(x => idAnimais.Contains(x.Id));

            var idClientes = animais.Select(x => x.IdCliente).Distinct();

            var clientes = await _clientesRepository.GetAsync(x => idClientes.Contains(x.Id));

            foreach (var agenda in agendaDia)
            {
                var agendaDto = new AgendaMarcadaDto();

                agendaDto.DataAtendimento = agenda.DataConsulta;
                var animal = animais.FirstOrDefault(x => x.Id == agenda.IdAnimal);
                agendaDto.NomeAnimal = animal.Nome;

                agendaDto.NomeCliente = clientes.FirstOrDefault(x => x.Id == animal.IdCliente).Nome;

                agendaDto.TipoAnimal = animal.Tipo.ToString();

                agendaDto.IdVeterinario = agenda.IdVeterinario;
                agendaDto.NomeVeterinario = veterinarios.FirstOrDefault(x => x.Id == agenda.IdVeterinario).Nome;

                listaDia.Add(agendaDto);
            }

            return listaDia;
        }

        public async Task<IList<AgendaVeterianarioDto>> CarregarListaVetDisponivelAsync(Animal animal, DateTime? dataAgendamento = null, int? idVeterinario = null)
        {
            IList<Veterinario> veterinarios = new List<Veterinario>();

            DateTime dataConsulta = dataAgendamento.HasValue ? dataAgendamento.Value : DateTime.Now;

            if (!idVeterinario.HasValue)
                veterinarios = await _veterinarioRepository.GetAsync();
            else
                veterinarios = await _veterinarioRepository.GetAsync(x => x.Id == idVeterinario.Value);

            var listaVetDisponivel = new List<AgendaVeterianarioDto>();



            if (animal.IsIdoso)
                veterinarios = veterinarios.Where(x => x.Geriatra).ToList();

            foreach (var vet in veterinarios)
            {
                var agendaOcupadaVet = await _agendamentoRepository.GetAsync(x => x.DataConsulta == dataConsulta && x.IdVeterinario == vet.Id);

                var horarioMarcados = agendaOcupadaVet.Select(x => x.DataConsulta.ToString("HH:mm")).Distinct();

                var horarioDisponivelVet = new AgendaVeterianarioDto()
                {
                    Veterianario = vet,
                    HorariosDiponiveis = HorarioDisponivelDefault(),
                    Dia = dataConsulta.ToString("dd/MM/yyyy")
                };

                horarioDisponivelVet.HorariosDiponiveis.ToList().RemoveAll(x => horarioMarcados.Contains(x));

                listaVetDisponivel.Add(horarioDisponivelVet);

            }
            return listaVetDisponivel;
        }

        private IList<string> HorarioDisponivelDefault()
        {
            var listaDeHorarios = new List<string>();
            var date = DateTime.ParseExact("2010-01-01 09:00:00", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

            for (int i = 0; i < 20; i++)
            {
                listaDeHorarios.Add(date.ToString("HH:mm"));
                date = date.AddMinutes(30);
            }

            return listaDeHorarios;
        }
    }
}
