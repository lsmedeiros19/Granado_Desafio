using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Models;
using System;

namespace PetCare.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Veterinario> Veterinario { get; set; }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Atendimento> Atendimento { get; set; }
        public DbSet<TipoAnimal> TipoAnimal { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public AppDbContext()
        { }

    }
}
