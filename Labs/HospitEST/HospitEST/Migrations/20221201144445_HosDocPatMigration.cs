using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitEST.Migrations
{
    public partial class HosDocPatMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Localization = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HospitalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Practice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PracticeYears = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Hospital_HospitalId",
                        column: x => x.HospitalId,
                        principalTable: "Hospital",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pathology = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "Localization", "Name" },
                values: new object[] { new Guid("146b64ac-5b50-44df-86a2-4f0f08e28ced"), "Setúbal", "Hospital do Outão" });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "Localization", "Name" },
                values: new object[] { new Guid("87834404-c4a4-4d43-8e85-a96b34611155"), "Lisboa", "Hospital da Luz" });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "HospitalId", "Name", "Practice", "PracticeYears" },
                values: new object[,]
                {
                    { new Guid("07e98f37-65b8-4462-bef0-ccbc27d88c76"), new Guid("146b64ac-5b50-44df-86a2-4f0f08e28ced"), "Miguel Neves", "Ortopedista", 13 },
                    { new Guid("6ee7512b-01c6-48a9-8bd4-c92afb1e47f4"), new Guid("87834404-c4a4-4d43-8e85-a96b34611155"), "Luis Silva", "Neurocirurgião", 19 },
                    { new Guid("998f7f05-be92-4deb-b34f-963a08c04b89"), new Guid("87834404-c4a4-4d43-8e85-a96b34611155"), "Manuel Esteves", "Medicina Geral e Familiar", 13 },
                    { new Guid("b213d507-b550-420f-9bac-8a09ad8eef36"), new Guid("146b64ac-5b50-44df-86a2-4f0f08e28ced"), "Sofia Feliz", "Pediatra", 4 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "DateOfBirth", "DoctorId", "Name", "Pathology" },
                values: new object[,]
                {
                    { new Guid("1d2c2acf-820f-476d-abe6-cac5f9aa561c"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b213d507-b550-420f-9bac-8a09ad8eef36"), "Maitê Alves", "Asperger" },
                    { new Guid("4c130963-8cfe-4cbc-9fff-6db264a34bd2"), new DateTime(1957, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ee7512b-01c6-48a9-8bd4-c92afb1e47f4"), "Helena Porto", "AVC" },
                    { new Guid("9dff071d-20cf-4f66-8f28-3927f090d4b1"), new DateTime(2001, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07e98f37-65b8-4462-bef0-ccbc27d88c76"), "David Nogueira", "Ombro deslocado" },
                    { new Guid("9faa375f-174b-49b0-957d-2b8bfba92e87"), new DateTime(2005, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07e98f37-65b8-4462-bef0-ccbc27d88c76"), "Daniel Moreira", "Cotovelo Rachado" },
                    { new Guid("b1d29e57-fe5e-4dca-81c7-6e0f952a276e"), new DateTime(2004, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("07e98f37-65b8-4462-bef0-ccbc27d88c76"), "António Campos", "Perna partida" },
                    { new Guid("ed79e406-88a1-4cc0-aa40-a7ddee7ea25f"), new DateTime(1984, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("998f7f05-be92-4deb-b34f-963a08c04b89"), "Ana Júlia Araújo", "Gripe" },
                    { new Guid("eff7ce41-1381-4c8f-9cdd-5d060b2c6c99"), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ee7512b-01c6-48a9-8bd4-c92afb1e47f4"), "Bernardo Pereira", "Traumatismo Craniano" },
                    { new Guid("ffa01f4d-6b70-4110-847c-7dd0f8f07ab2"), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("6ee7512b-01c6-48a9-8bd4-c92afb1e47f4"), "Otávio Campos", "Tumor no cérebro" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_HospitalId",
                table: "Doctor",
                column: "HospitalId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_DoctorId",
                table: "Patient",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Hospital");
        }
    }
}
