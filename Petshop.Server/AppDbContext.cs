using Microsoft.EntityFrameworkCore;
using PetshopOA.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petshop.Server
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<PetshopOA.Shared.Petshop> Petshops { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Servico> Servico { get; set; }
        public DbSet<Contrato> Contrato { get; set; }

        //Essa parte é para fazer o relacionamento um para um
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                       .HasOne(f => f.Contrato)
                       .WithOne(c => c.Funcionario)
                       .HasForeignKey<Contrato>(c => c.FuncionarioId);
        }
    }
}
