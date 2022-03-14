using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetserver.Data.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Set = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CollectorNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardBackFace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UriLarge = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UriNormal = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UriSmall = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardBackFace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardBackFace_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardFrontFace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UriLarge = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UriNormal = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    UriSmall = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardFrontFace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardFrontFace_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPriceEur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPriceEur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPriceEur_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPriceEurFoil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPriceEurFoil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPriceEurFoil_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPriceUsd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPriceUsd", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPriceUsd_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPriceUsdEtched",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPriceUsdEtched", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPriceUsdEtched_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPriceUsdFoil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPriceUsdFoil", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPriceUsdFoil_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardPriceUsdGlossy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardPriceUsdGlossy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardPriceUsdGlossy_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EtchedFinish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtchedFinish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EtchedFinish_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoilFinish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoilFinish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoilFinish_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GlossyFinish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlossyFinish", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlossyFinish_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Record",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(type: "TEXT", nullable: false),
                    End = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Record", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Record_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecordPriceEur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    RecordId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordPriceEur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordPriceEur_Card_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Possession",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    Finish = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Possession_Card_CardId",
                        column: x => x.CardId,
                        principalTable: "Card",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Possession_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[] { 1, "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_CardBackFace_CardId",
                table: "CardBackFace",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardFrontFace_CardId",
                table: "CardFrontFace",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPriceEur_CardId",
                table: "CardPriceEur",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPriceEurFoil_CardId",
                table: "CardPriceEurFoil",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPriceUsd_CardId",
                table: "CardPriceUsd",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPriceUsdEtched_CardId",
                table: "CardPriceUsdEtched",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPriceUsdFoil_CardId",
                table: "CardPriceUsdFoil",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_CardPriceUsdGlossy_CardId",
                table: "CardPriceUsdGlossy",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_EtchedFinish_CardId",
                table: "EtchedFinish",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_FoilFinish_CardId",
                table: "FoilFinish",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_GlossyFinish_CardId",
                table: "GlossyFinish",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Possession_CardId",
                table: "Possession",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Possession_UserId",
                table: "Possession",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Record_CardId",
                table: "Record",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_RecordPriceEur_RecordId",
                table: "RecordPriceEur",
                column: "RecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardBackFace");

            migrationBuilder.DropTable(
                name: "CardFrontFace");

            migrationBuilder.DropTable(
                name: "CardPriceEur");

            migrationBuilder.DropTable(
                name: "CardPriceEurFoil");

            migrationBuilder.DropTable(
                name: "CardPriceUsd");

            migrationBuilder.DropTable(
                name: "CardPriceUsdEtched");

            migrationBuilder.DropTable(
                name: "CardPriceUsdFoil");

            migrationBuilder.DropTable(
                name: "CardPriceUsdGlossy");

            migrationBuilder.DropTable(
                name: "EtchedFinish");

            migrationBuilder.DropTable(
                name: "FoilFinish");

            migrationBuilder.DropTable(
                name: "GlossyFinish");

            migrationBuilder.DropTable(
                name: "Possession");

            migrationBuilder.DropTable(
                name: "Record");

            migrationBuilder.DropTable(
                name: "RecordPriceEur");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Card");
        }
    }
}
