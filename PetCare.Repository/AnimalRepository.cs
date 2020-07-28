using PetCare.Domain.Models;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetCare.Repository
{
    public class AnimalRepository : GenericRepository<Animal>, IAnimalRepository
    {
        private readonly AppDbContext _dbContext;

        public AnimalRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
