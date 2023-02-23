using MediESTeca.Areas.Identity.Data;
using MediESTeca.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediESTeca.Data;

public class MediESTecaComIdentityContext : IdentityDbContext<Utente>
{
    public MediESTecaComIdentityContext(DbContextOptions<MediESTecaComIdentityContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        PasswordHasher<Utente> ph = new PasswordHasher<Utente>();

        Utente admin = new Utente
        {
            UserName = "admin@ips.pt",
            NormalizedUserName = "admin@ips.pt".ToUpper(),
            Email = "admin@ips.pt",
            NormalizedEmail = "admin@ips.pt".ToUpper(),
            TwoFactorEnabled = false,
            EmailConfirmed = true,
            PhoneNumber = "123456789",
            PhoneNumberConfirmed = false,

            Nome = "admin",
            Telefone = 123456789
        };
        admin.PasswordHash = ph.HashPassword(admin, "123456");


        Utente joao = new Utente
        {
            UserName = "jonas@ip.pt",
            NormalizedUserName = "jonas@ip.pt".ToUpper(),
            Email = "jonas@ip.pt",
            NormalizedEmail = "jonas@ip.pt".ToUpper(),
            TwoFactorEnabled = false,
            EmailConfirmed = true,
            PhoneNumber = "123456789",
            PhoneNumberConfirmed = false,

            Nome = "João Manuel",
            Telefone = 1234567890
        };
        joao.PasswordHash = ph.HashPassword(joao, "123456");

        Utente ana = new Utente
        {
            UserName = "ana@gmail.com",
            NormalizedUserName = "ana@gmail.com".ToUpper(),
            Email = "ana@gmail.com",
            NormalizedEmail = "ana@gmail.com".ToUpper(),
            TwoFactorEnabled = false,
            EmailConfirmed = true,
            PhoneNumber = "234567890",
            PhoneNumberConfirmed = false,

            Nome = "Ana",
            Telefone = 1234567890
        };
        ana.PasswordHash = ph.HashPassword(ana, "123456");


        builder.Entity<Utente>().HasData(
            admin,
            joao,
            ana
        );

        IdentityRole adminsRole = new IdentityRole
        {
            Name = "admins",
            NormalizedName = "admins".ToUpper()
        };
        IdentityRole usersRole = new IdentityRole
        {
            Name = "users",
            NormalizedName = "users".ToUpper()
        };

        builder.Entity<IdentityRole>().HasData(
           adminsRole,
           usersRole
        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = adminsRole.Id, UserId = admin.Id },
            new IdentityUserRole<string> { RoleId = usersRole.Id, UserId = joao.Id },
            new IdentityUserRole<string> { RoleId = usersRole.Id, UserId = ana.Id }
        );


        builder.Entity<Livro>().HasData(
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
    }

    public DbSet<MediESTeca.Models.Livro> Livro { get; set; }

    public DbSet<MediESTeca.Models.Requisicao> Requisicao { get; set; }
}
