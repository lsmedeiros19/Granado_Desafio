using PetCare.Domain.Models;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetCare.Repository
{
    public class AgendamentoRepository : GenericRepository<Agendamento>, IAgendamentoRepository
    {
        private readonly AppDbContext _dbContext;

        public AgendamentoRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
