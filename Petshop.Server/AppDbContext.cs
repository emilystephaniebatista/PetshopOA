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

            Seed(modelBuilder); 
            base.OnModelCreating(modelBuilder);
            
        }
        //inserção do seed: é necessário ter alguns valores pré cadastrados e por isso é implementado o seed
        public void Seed(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Autorizacao>().HasData(new Autorizacao
            {
                Id = 1,
            });

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                Email = "emily@teste.com.br",
                Senha = "123456",
                AutorizacaoId = 1
            }); 
            
            
        }

        //Essa parte é para fazer o relacionamento um para um
        public DbSet<PetshopOA.Shared.Usuario> Usuario { get; set; }

        //Essa parte é para fazer o relacionamento um para um
        public DbSet<PetshopOA.Shared.Autorizacao> Autorizacao { get; set; }
    }
}
