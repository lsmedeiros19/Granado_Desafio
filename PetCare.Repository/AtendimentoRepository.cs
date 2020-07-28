using PetCare.Domain.Models;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetCare.Repository
{
    public class AtendimentoRepository : GenericRepository<Atendimento>, IAtendimentoRepository
    {
        private readonly AppDbContext _dbContext;

        public AtendimentoRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
