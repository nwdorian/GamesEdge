using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable

namespace Infrastructure.Database.Migrations;

/// <inheritdoc />
public partial class AddGameEntity : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Game",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                DeletedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Game", x => x.Id);
                table.ForeignKey(
                    name: "FK_Game_AspNetUsers_CreatedBy",
                    column: x => x.CreatedBy,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict
                );
                table.ForeignKey(
                    name: "FK_Game_AspNetUsers_DeletedBy",
                    column: x => x.DeletedBy,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict
                );
                table.ForeignKey(
                    name: "FK_Game_AspNetUsers_UpdatedBy",
                    column: x => x.UpdatedBy,
                    principalTable: "AspNetUsers",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Restrict
                );
            }
        );

        migrationBuilder.CreateIndex(name: "IX_Game_CreatedBy", table: "Game", column: "CreatedBy");

        migrationBuilder.CreateIndex(name: "IX_Game_DeletedBy", table: "Game", column: "DeletedBy");

        migrationBuilder.CreateIndex(name: "IX_Game_IsDeleted", table: "Game", column: "IsDeleted");

        migrationBuilder.CreateIndex(name: "IX_Game_Name", table: "Game", column: "Name", unique: true);

        migrationBuilder.CreateIndex(name: "IX_Game_UpdatedBy", table: "Game", column: "UpdatedBy");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Game");
    }
}
