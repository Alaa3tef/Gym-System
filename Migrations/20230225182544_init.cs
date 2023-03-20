using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymSysyemWpf.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Buyprotiens",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtienName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantaty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyprotiens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Buyprotiens_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "GymMachines",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymMachines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GymMachines_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Receptionists",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptionists", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receptionists_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vendors_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Coaches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    ReceptionistID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coaches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Coaches_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Coaches_Receptionists_ReceptionistID",
                        column: x => x.ReceptionistID,
                        principalTable: "Receptionists",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProtienProducts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    ReceptionistID = table.Column<int>(type: "int", nullable: false),
                    Quantaty = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    BuyProtienID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProtienProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProtienProducts_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProtienProducts_Buyprotiens_BuyProtienID",
                        column: x => x.BuyProtienID,
                        principalTable: "Buyprotiens",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProtienProducts_Receptionists_ReceptionistID",
                        column: x => x.ReceptionistID,
                        principalTable: "Receptionists",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", nullable: false),
                    ReceptionistID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Subscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    CoachID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trainees_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Trainees_Coaches_CoachID",
                        column: x => x.CoachID,
                        principalTable: "Coaches",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Trainees_Receptionists_ReceptionistID",
                        column: x => x.ReceptionistID,
                        principalTable: "Receptionists",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyprotiens_AdminID",
                table: "Buyprotiens",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_AdminID",
                table: "Coaches",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_ReceptionistID",
                table: "Coaches",
                column: "ReceptionistID");

            migrationBuilder.CreateIndex(
                name: "IX_GymMachines_AdminID",
                table: "GymMachines",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_ProtienProducts_AdminID",
                table: "ProtienProducts",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_ProtienProducts_BuyProtienID",
                table: "ProtienProducts",
                column: "BuyProtienID");

            migrationBuilder.CreateIndex(
                name: "IX_ProtienProducts_ReceptionistID",
                table: "ProtienProducts",
                column: "ReceptionistID");

            migrationBuilder.CreateIndex(
                name: "IX_Receptionists_AdminID",
                table: "Receptionists",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_AdminID",
                table: "Trainees",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_CoachID",
                table: "Trainees",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_ReceptionistID",
                table: "Trainees",
                column: "ReceptionistID");

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_AdminID",
                table: "Vendors",
                column: "AdminID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GymMachines");

            migrationBuilder.DropTable(
                name: "ProtienProducts");

            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Buyprotiens");

            migrationBuilder.DropTable(
                name: "Coaches");

            migrationBuilder.DropTable(
                name: "Receptionists");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
