using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ESTGym.Models;

namespace ESTGym.Data
{
    public class ESTGymContext : DbContext
    {
        public ESTGymContext (DbContextOptions<ESTGymContext> options)
            : base(options)
        {
        }

        public DbSet<ESTGym.Models.Person> Person { get; set; }
    }
}
