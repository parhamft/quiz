using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quiz.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardNumber = table.Column<string>(type: "nchar(16)", nullable: false),
                    HolderName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false),
                    tries = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardNumber);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceCardNumber = table.Column<string>(type: "nchar(16)", nullable: false),
                    DestinationCardNumber = table.Column<string>(type: "nchar(16)", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isSuccessful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_transactions_Cards_DestinationCardNumber",
                        column: x => x.DestinationCardNumber,
                        principalTable: "Cards",
                        principalColumn: "CardNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transactions_Cards_SourceCardNumber",
                        column: x => x.SourceCardNumber,
                        principalTable: "Cards",
                        principalColumn: "CardNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transactions_DestinationCardNumber",
                table: "transactions",
                column: "DestinationCardNumber");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_SourceCardNumber",
                table: "transactions",
                column: "SourceCardNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
