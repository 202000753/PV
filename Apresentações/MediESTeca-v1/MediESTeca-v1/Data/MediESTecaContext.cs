using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MediESTeca_v1.Models;

namespace MediESTeca_v1.Data
{
    public class MediESTecaContext : DbContext
    {
        public MediESTecaContext (DbContextOptions<MediESTecaContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Livro>().HasData(
                new Livro
                {
                    Id = 1,
                    Isbn = "0868910341",
                    Titulo = "ASP.NET MVC 6",
                    Autor = "Bill Gates",
                    AnoEdicao = 2015
                },
                new Livro
                {
                    Id = 2,
                    Isbn = "0145190277",
                    Titulo = "WPF For Dummies",
                    Autor = "José Braz",
                    AnoEdicao = 2015
                },
                new Livro
                {
                    Id = 3,
                    Isbn = "0501083731",
                    Titulo = "Entity Framework 6",
                    Autor = "Paul Alen",
                    AnoEdicao = 2014
                }
            );

            modelBuilder.Entity<Utente>().HasData(
                 new Utente
                 {
                     Id = 1,
                     Nome = "João Manuel",
                     Telefone = 123456789
                 },

                new Utente
                {
                    Id = 2,
                    Nome = "Ana Sofia",
                    Telefone = 234567890
                }
            );
        }

        public DbSet<MediESTeca_v1.Models.Utente> Utente { get; set; } = default!;

        public DbSet<MediESTeca_v1.Models.Livro> Livro { get; set; }

        public DbSet<MediESTeca_v1.Models.Requisicao> Requisicao { get; set; }
    }
}
