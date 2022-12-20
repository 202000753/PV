using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitEST.Migrations
{
    public partial class Initial : Migration
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
                values: new object[] { new Guid("40e2cbf4-1add-4f6d-9a2b-a49cc642267e"), "Lisboa", "Hospital da Luz" });

            migrationBuilder.InsertData(
                table: "Hospital",
                columns: new[] { "Id", "Localization", "Name" },
                values: new object[] { new Guid("60a0b04c-d87f-4b81-a247-f6f3d18fd856"), "Setúbal", "Hospital do Outão" });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "HospitalId", "Name", "Practice", "PracticeYears" },
                values: new object[,]
                {
                    { new Guid("50f604f5-2cb0-4fc4-82b3-dc90a1b59016"), new Guid("60a0b04c-d87f-4b81-a247-f6f3d18fd856"), "Sofia Feliz", "Pediatra", 4 },
                    { new Guid("56226013-9ded-42c3-adb5-5ce8cb276d98"), new Guid("60a0b04c-d87f-4b81-a247-f6f3d18fd856"), "Miguel Neves", "Ortopedista", 13 },
                    { new Guid("77f8e67a-89b8-40af-8a4d-a26050be99b7"), new Guid("40e2cbf4-1add-4f6d-9a2b-a49cc642267e"), "Luis Silva", "Neurocirurgião", 19 },
                    { new Guid("b2b60a21-79c0-4461-b670-6ce5fff5d2ed"), new Guid("40e2cbf4-1add-4f6d-9a2b-a49cc642267e"), "Manuel Esteves", "Medicina Geral e Familiar", 13 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "DateOfBirth", "DoctorId", "Name", "Pathology" },
                values: new object[,]
                {
                    { new Guid("252e82ee-85f8-4491-95e6-55da3069a24d"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("50f604f5-2cb0-4fc4-82b3-dc90a1b59016"), "Maitê Alves", "Asperger" },
                    { new Guid("35c65d9a-9486-40e4-8836-9eb0c48f03df"), new DateTime(2005, 4, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("56226013-9ded-42c3-adb5-5ce8cb276d98"), "Daniel Moreira", "Cotovelo Rachado" },
                    { new Guid("3b34664f-7a9f-4e9a-8cf9-2b42559ae37a"), new DateTime(1957, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("77f8e67a-89b8-40af-8a4d-a26050be99b7"), "Helena Porto", "AVC" },
                    { new Guid("482c6b05-dcc6-4ae0-bac0-8172482abb73"), new DateTime(2001, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("56226013-9ded-42c3-adb5-5ce8cb276d98"), "David Nogueira", "Ombro deslocado" },
                    { new Guid("87d9fae4-164d-426d-b735-696ac4d6e664"), new DateTime(1984, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b2b60a21-79c0-4461-b670-6ce5fff5d2ed"), "Ana Júlia Araújo", "Gripe" },
                    { new Guid("be811d87-b076-4952-a991-6c1c4692dd05"), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("77f8e67a-89b8-40af-8a4d-a26050be99b7"), "Otávio Campos", "Tumor no cérebro" },
                    { new Guid("d9c3a83b-d164-4b3d-b59f-8dc3f72d5c7d"), new DateTime(1990, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("77f8e67a-89b8-40af-8a4d-a26050be99b7"), "Bernardo Pereira", "Traumatismo Craniano" },
                    { new Guid("e29f6673-f6d0-48c6-ad49-6ae2323942a2"), new DateTime(2004, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("56226013-9ded-42c3-adb5-5ce8cb276d98"), "António Campos", "Perna partida" }
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
