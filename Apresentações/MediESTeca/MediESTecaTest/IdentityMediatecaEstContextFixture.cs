using MediESTeca.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediESTecaTest
{
    public class IdentityMediatecaEstContextFixture
    {
        public MediESTecaComIdentityContext DbContext { get; private set; }

        public IdentityMediatecaEstContextFixture()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<MediESTecaComIdentityContext>()
                .UseSqlite(connection)
                .Options;
            DbContext = new MediESTecaComIdentityContext(options);


            DbContext.Database.EnsureCreated();
        }
    }
}
