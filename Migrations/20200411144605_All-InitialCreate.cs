using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EventOrganizer.Migrations
{
    public partial class AllInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "organizer",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    image_location = table.Column<string>(type: "text", nullable: true),
                    is_active = table.Column<bool>(nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    is_active = table.Column<bool>(nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    organizer_id = table.Column<Guid>(nullable: true),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    type = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    held_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    start_time = table.Column<TimeSpan>(nullable: true),
                    end_time = table.Column<TimeSpan>(nullable: true),
                    is_active = table.Column<bool>(nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.id);
                    table.ForeignKey(
                        name: "FK_26",
                        column: x => x.organizer_id,
                        principalTable: "organizer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    role_id = table.Column<Guid>(nullable: true),
                    organizer_id = table.Column<Guid>(nullable: true),
                    name = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    username = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    password = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    avatar = table.Column<string>(type: "text", nullable: true),
                    gender = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "text", nullable: true),
                    join_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    last_login = table.Column<DateTime>(type: "datetime", nullable: true),
                    is_active = table.Column<bool>(nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_54",
                        column: x => x.organizer_id,
                        principalTable: "organizer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_51",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fkIdx_26",
                table: "event",
                column: "organizer_id");

            migrationBuilder.CreateIndex(
                name: "fkIdx_54",
                table: "user",
                column: "organizer_id");

            migrationBuilder.CreateIndex(
                name: "fkIdx_51",
                table: "user",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "organizer");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
