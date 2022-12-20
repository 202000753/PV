using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HospitEST.Models;

namespace HospitEST.Data
{
    public class HospitESTContext : DbContext
    {
        public HospitESTContext(DbContextOptions<HospitESTContext> options)
            : base(options)
        {
        }

        //Nivel 4
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Save list of Ids for the relations hospital-doctors and doctor-patients
            List<Guid> HospitalIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() }; 
            List<Guid> DoctorIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };
            
            modelBuilder.Entity<Hospital>().HasData(
                    new Hospital
                    {
                        Id = HospitalIds[0],
                        Name = "Hospital da Luz",
                        Localization = "Lisboa"
                    },
                    new Hospital
                    {
                        Id = HospitalIds[1],
                        Name = "Hospital do Outão",
                        Localization = "Setúbal"
                    }
                );

            modelBuilder.Entity<Doctor>().HasData(
                    new Doctor
                    {
                        Id = DoctorIds[0],
                        HospitalId = HospitalIds[0],
                        Name = "Luis Silva",
                        Practice = "Neurocirurgião",
                        PracticeYears = 19
                    },
                    new Doctor
                    {
                        Id = DoctorIds[1],
                        HospitalId = HospitalIds[0],
                        Name = "Manuel Esteves",
                        Practice = "Medicina Geral e Familiar",
                        PracticeYears = 13
                    },
                    new Doctor
                    {
                        Id = DoctorIds[2],
                        HospitalId = HospitalIds[1],
                        Name = "Sofia Feliz",
                        Practice = "Pediatra",
                        PracticeYears = 4
                    },
                    new Doctor
                    {
                        Id = DoctorIds[3],
                        HospitalId = HospitalIds[1],
                        Name = "Miguel Neves",
                        Practice = "Ortopedista",
                        PracticeYears = 13
                    }
                );

            modelBuilder.Entity<Patient>().HasData(
                        new Patient
                        {
                            Id = Guid.NewGuid(),
                            DoctorId = DoctorIds[0],
                            Name = "Bernardo Pereira",
                            DateOfBirth = new DateTime(1990, 03, 22),
                            Pathology = "Traumatismo Craniano"
                        },
                        new Patient
                        {
                            Id = Guid.NewGuid(),
                            DoctorId = DoctorIds[0],
                            Name = "Helena Porto",
                            DateOfBirth = new DateTime(1957, 07, 30),
                            Pathology = "AVC"
                        },
                        new Patient
                        {
                            Id = Guid.NewGuid(),
                            DoctorId = DoctorIds[0],
                            Name = "Otávio Campos",
                            DateOfBirth = new DateTime(1990, 03, 22),
                            Pathology = "Tumor no cérebro"
                        },
                        new Patient
                        {
                            Id = Guid.NewGuid(),
                            DoctorId = DoctorIds[1],
                            Name = "Ana Júlia Araújo",
                            DateOfBirth = new DateTime(1984, 01, 08),
                            Pathology = "Gripe"
                        },
                        new Patient
                        {
                            Id = Guid.NewGuid(),
                            DoctorId = DoctorIds[2],
                            Name = "Maitê Alves",
                            DateOfBirth = new DateTime(2019, 10, 14),
                            Pathology = "Asperger"
                        },
                        new Patient
                        {
                            Id = Guid.NewGuid(),
                            DoctorId = DoctorIds[3],
                            Name = "António Campos",
                            DateOfBirth = new DateTime(2004, 12, 12),
                            Pathology = "Perna partida"
                        },
                        new Patient
                        {
                            Id = Guid.NewGuid(),
                            DoctorId = DoctorIds[3],
                            Name = "Daniel Moreira",
                            DateOfBirth = new DateTime(2005, 04, 29),
                            Pathology = "Cotovelo Rachado"
                        },
                        new Patient
                        {
                            Id = Guid.NewGuid(),
                            DoctorId = DoctorIds[3],
                            Name = "David Nogueira",
                            DateOfBirth = new DateTime(2001, 04, 13),
                            Pathology = "Ombro deslocado"
                        }
                );
    }

        public DbSet<HospitEST.Models.Patient> Patient { get; set; } = default!;

        public DbSet<HospitEST.Models.Doctor> Doctor { get; set; }

        public DbSet<HospitEST.Models.Hospital> Hospital { get; set; }
    }
}
