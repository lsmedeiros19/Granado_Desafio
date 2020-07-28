using PetCare.Domain.Models;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetCare.Repository
{
    public class VeterinarioRepository : GenericRepository<Veterinario>, IVeterinarioRepository
    {
        private readonly AppDbContext _dbContext;

        public VeterinarioRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
