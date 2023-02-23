using ESTeSoccer.Data;
using ESTeSoccerMVC.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTeSoccerTest
{
    public class ApplicationDbContextFixture : IDisposable
    {
        public ESTeSoccerContext DbContext { get; private set; }

        public ApplicationDbContextFixture()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<ESTeSoccerContext>()
                    .UseSqlite(connection)
                    .Options;
            DbContext = new ESTeSoccerContext(options);

            DbContext.Database.EnsureCreated();

            //Nivel 2
            // Adicionar Ligas para testes
            DbContext.League.Add(new League { LeagueId = 3, Name = "Liga SABSEG", Country = "Portugal" });

            //Nivel 3
            DbContext.Team.AddRange(
                new Team {
                    TeamId = 8,
                    LeagueId = 3,
                    Name = "Estoril Praia",
                    Initials = "EST",
                    NumberOfTitles = 3,
                    MainColor = "Branco"
                },
                new Team {
                    TeamId = 9,
                    LeagueId = 3,
                    Name = "FC Arouca",
                    Initials = "ARC",
                    NumberOfTitles = 0,
                    MainColor = "Amarelo"
                });

            DbContext.SaveChanges();
        }

        public void Dispose() => DbContext.Dispose();
    }
}
