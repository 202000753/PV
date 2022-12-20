using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitEST.Migrations
{
    public partial class seeddata : Migration
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
                values: new object[] { new Guid("9353a098-5331-49ad-adb8-5d7df000ba0e"), "Lisboa", "Hospital da Luz" });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "Localization", "Name" },
                values: new object[] { new Guid("9cf83986-9889-4e53-af22-abe7ea82b071"), "Setúbal", "Hospital do Outão" });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "HospitalId", "Name", "Practice", "PracticeYears" },
                values: new object[,]
                {
                    { new Guid("04d615ec-6f55-4393-b66f-f7d4bb909ccf"), new Guid("9cf83986-9889-4e53-af22-abe7ea82b071"), "Miguel Neves", "Ortopedista", 13 },
                    { new Guid("2ee23247-fb5c-415c-9520-65012df8ae2c"), new Guid("9cf83986-9889-4e53-af22-abe7ea82b071"), "Luis Silva", "Pediatra", 4 },
                    { new Guid("4c5d8607-333d-4ddd-a6dc-70d1fe153dd3"), new Guid("9353a098-5331-49ad-adb8-5d7df000ba0e"), "Luis Silva", "Neurocirurgião", 19 },
                    { new Guid("a905dba8-7d95-411e-867e-f8a752a71735"), new Guid("9353a098-5331-49ad-adb8-5d7df000ba0e"), "Manuel Esteves", "Medicina Geral e Familiar", 13 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "DateOfBirth", "DoctorId", "Name", "Pathology" },
                values: new object[,]
                {
                    { new Guid("096c4325-52cf-4d63-94bf-8e360ec59efd"), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4c5d8607-333d-4ddd-a6dc-70d1fe153dd3"), "Otávio Campos", "Tumor no cérebro" },
                    { new Guid("25ed66db-46bd-419b-b9f6-2acb6d712de4"), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4c5d8607-333d-4ddd-a6dc-70d1fe153dd3"), "Bernardo Pereira", "Traumatismo Craniano" },
                    { new Guid("30abbe19-4f8e-41d9-8777-9614bccdcae8"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("2ee23247-fb5c-415c-9520-65012df8ae2c"), "Maitê Alves", "Asperger" },
                    { new Guid("4430d11a-8e4b-4b48-a6b3-aa00c22c62ba"), new DateTime(2005, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04d615ec-6f55-4393-b66f-f7d4bb909ccf"), "Daniel Moreira", "Cotovelo Rachado" },
                    { new Guid("57561df7-8711-4e25-a36f-5a59f00ec86b"), new DateTime(2001, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04d615ec-6f55-4393-b66f-f7d4bb909ccf"), "David Nogueira", "Ombro deslocado" },
                    { new Guid("6f8bdf2c-f8c5-4fe9-878b-5b466455e46e"), new DateTime(2004, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("04d615ec-6f55-4393-b66f-f7d4bb909ccf"), "António Campos", "Perna partida" },
                    { new Guid("c4b82411-5c80-4093-bf70-567253b6db9b"), new DateTime(1984, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a905dba8-7d95-411e-867e-f8a752a71735"), "Ana Júlia Araújo", "Gripe" },
                    { new Guid("d22b9285-691d-4e58-865f-57664068b77d"), new DateTime(1957, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4c5d8607-333d-4ddd-a6dc-70d1fe153dd3"), "Helena Porto", "AVC" }
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
