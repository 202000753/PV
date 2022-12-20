using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi.Data
{
    public class StudentWebApiContext : DbContext
    {
        public StudentWebApiContext (DbContextOptions<StudentWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<StudentWebApi.Models.Student> Student { get; set; } = default!;
    }
}
