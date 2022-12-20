﻿// <auto-generated />
using System;
using HospitEST.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitEST.Migrations
{
    [DbContext(typeof(HospitESTContext))]
    [Migration("20221201144445_HosDocPatMigration")]
    partial class HosDocPatMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HospitEST.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HospitalId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Practice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PracticeYears")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Doctor");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6ee7512b-01c6-48a9-8bd4-c92afb1e47f4"),
                            HospitalId = new Guid("87834404-c4a4-4d43-8e85-a96b34611155"),
                            Name = "Luis Silva",
                            Practice = "Neurocirurgião",
                            PracticeYears = 19
                        },
                        new
                        {
                            Id = new Guid("998f7f05-be92-4deb-b34f-963a08c04b89"),
                            HospitalId = new Guid("87834404-c4a4-4d43-8e85-a96b34611155"),
                            Name = "Manuel Esteves",
                            Practice = "Medicina Geral e Familiar",
                            PracticeYears = 13
                        },
                        new
                        {
                            Id = new Guid("b213d507-b550-420f-9bac-8a09ad8eef36"),
                            HospitalId = new Guid("146b64ac-5b50-44df-86a2-4f0f08e28ced"),
                            Name = "Sofia Feliz",
                            Practice = "Pediatra",
                            PracticeYears = 4
                        },
                        new
                        {
                            Id = new Guid("07e98f37-65b8-4462-bef0-ccbc27d88c76"),
                            HospitalId = new Guid("146b64ac-5b50-44df-86a2-4f0f08e28ced"),
                            Name = "Miguel Neves",
                            Practice = "Ortopedista",
                            PracticeYears = 13
                        });
                });

            modelBuilder.Entity("HospitEST.Models.Hospital", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Localization")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Hospital");

                    b.HasData(
                        new
                        {
                            Id = new Guid("87834404-c4a4-4d43-8e85-a96b34611155"),
                            Localization = "Lisboa",
                            Name = "Hospital da Luz"
                        },
                        new
                        {
                            Id = new Guid("146b64ac-5b50-44df-86a2-4f0f08e28ced"),
                            Localization = "Setúbal",
                            Name = "Hospital do Outão"
                        });
                });

            modelBuilder.Entity("HospitEST.Models.Patient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DoctorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pathology")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patient");

                    b.HasData(
                        new
                        {
                            Id = new Guid("eff7ce41-1381-4c8f-9cdd-5d060b2c6c99"),
                            DateOfBirth = new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("6ee7512b-01c6-48a9-8bd4-c92afb1e47f4"),
                            Name = "Bernardo Pereira",
                            Pathology = "Traumatismo Craniano"
                        },
                        new
                        {
                            Id = new Guid("4c130963-8cfe-4cbc-9fff-6db264a34bd2"),
                            DateOfBirth = new DateTime(1957, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("6ee7512b-01c6-48a9-8bd4-c92afb1e47f4"),
                            Name = "Helena Porto",
                            Pathology = "AVC"
                        },
                        new
                        {
                            Id = new Guid("ffa01f4d-6b70-4110-847c-7dd0f8f07ab2"),
                            DateOfBirth = new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("6ee7512b-01c6-48a9-8bd4-c92afb1e47f4"),
                            Name = "Otávio Campos",
                            Pathology = "Tumor no cérebro"
                        },
                        new
                        {
                            Id = new Guid("ed79e406-88a1-4cc0-aa40-a7ddee7ea25f"),
                            DateOfBirth = new DateTime(1984, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("998f7f05-be92-4deb-b34f-963a08c04b89"),
                            Name = "Ana Júlia Araújo",
                            Pathology = "Gripe"
                        },
                        new
                        {
                            Id = new Guid("1d2c2acf-820f-476d-abe6-cac5f9aa561c"),
                            DateOfBirth = new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("b213d507-b550-420f-9bac-8a09ad8eef36"),
                            Name = "Maitê Alves",
                            Pathology = "Asperger"
                        },
                        new
                        {
                            Id = new Guid("b1d29e57-fe5e-4dca-81c7-6e0f952a276e"),
                            DateOfBirth = new DateTime(2004, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("07e98f37-65b8-4462-bef0-ccbc27d88c76"),
                            Name = "António Campos",
                            Pathology = "Perna partida"
                        },
                        new
                        {
                            Id = new Guid("9faa375f-174b-49b0-957d-2b8bfba92e87"),
                            DateOfBirth = new DateTime(2005, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("07e98f37-65b8-4462-bef0-ccbc27d88c76"),
                            Name = "Daniel Moreira",
                            Pathology = "Cotovelo Rachado"
                        },
                        new
                        {
                            Id = new Guid("9dff071d-20cf-4f66-8f28-3927f090d4b1"),
                            DateOfBirth = new DateTime(2001, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = new Guid("07e98f37-65b8-4462-bef0-ccbc27d88c76"),
                            Name = "David Nogueira",
                            Pathology = "Ombro deslocado"
                        });
                });

            modelBuilder.Entity("HospitEST.Models.Doctor", b =>
                {
                    b.HasOne("HospitEST.Models.Hospital", "Hospital")
                        .WithMany("Doctors")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hospital");
                });

            modelBuilder.Entity("HospitEST.Models.Patient", b =>
                {
                    b.HasOne("HospitEST.Models.Doctor", "Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitEST.Models.Doctor", b =>
                {
                    b.Navigation("Patients");
                });

            modelBuilder.Entity("HospitEST.Models.Hospital", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}
