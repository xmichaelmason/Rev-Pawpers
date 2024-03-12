using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "Dwelling",
                columns: table => new
                {
                    dwelling_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dwelling_type = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dwelling", x => x.dwelling_id);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    state_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    state_code = table.Column<string>(type: "nchar(2)", fixedLength: true, maxLength: 2, nullable: false),
                    state_name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.state_id);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    profile_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    profile_name = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_streetaddress = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_city = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_stateid = table.Column<int>(type: "int", nullable: false),
                    profile_zipcode = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    profile_age = table.Column<int>(type: "int", nullable: false),
                    profile_homephone = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    profile_personalphone = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    profile_email = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_occupation = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_spousename = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    profile_children = table.Column<int>(type: "int", nullable: false),
                    profile_dwellingid = table.Column<int>(type: "int", nullable: false),
                    profile_hasyard = table.Column<int>(type: "int", nullable: false),
                    profile_landlordname = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    profile_landlordphone = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    profile_otherpetname = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    profile_otherpetbreed = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true),
                    profile_otherpetsex = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: true),
                    profile_otherpetage = table.Column<int>(type: "int", nullable: true),
                    profile_familyallergies = table.Column<int>(type: "int", nullable: false),
                    profile_responsiblefordog = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_adoptionreason = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_dogsleepat = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_dogaggresive = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_medfordog = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false),
                    profile_nocaredog = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.profile_id);
                    table.ForeignKey(
                        name: "pro_dwe_FK",
                        column: x => x.profile_dwellingid,
                        principalTable: "Dwelling",
                        principalColumn: "dwelling_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "pro_sta_FK",
                        column: x => x.profile_stateid,
                        principalTable: "state",
                        principalColumn: "state_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Favorite",
                columns: table => new
                {
                    fav_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dog_id = table.Column<int>(type: "int", nullable: false),
                    is_available = table.Column<int>(type: "int", nullable: false),
                    profile_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Favorite__9694C47596BC756E", x => x.fav_id);
                    table.ForeignKey(
                        name: "FK__Favorite__profil__6E01572D",
                        column: x => x.profile_id,
                        principalTable: "Profile",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    topic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    topic_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    topic_body = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    profile_id = table.Column<int>(type: "int", nullable: true),
                    post_timestamp = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    category_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.topic_id);
                    table.ForeignKey(
                        name: "FK__Topic__category___73BA3083",
                        column: x => x.category_id,
                        principalTable: "Category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Topic__profile_i__6EF57B66",
                        column: x => x.profile_id,
                        principalTable: "Profile",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reply",
                columns: table => new
                {
                    reply_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reply_message = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    reply_timestamp = table.Column<DateTime>(type: "datetime", nullable: true),
                    profile_id = table.Column<int>(type: "int", nullable: true),
                    topic_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reply", x => x.reply_id);
                    table.ForeignKey(
                        name: "FK__Reply__profile_i__71D1E811",
                        column: x => x.profile_id,
                        principalTable: "Profile",
                        principalColumn: "profile_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Reply__topic_id__72C60C4A",
                        column: x => x.topic_id,
                        principalTable: "Topic",
                        principalColumn: "topic_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Favorite_profile_id",
                table: "Favorite",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_profile_dwellingid",
                table: "Profile",
                column: "profile_dwellingid");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_profile_stateid",
                table: "Profile",
                column: "profile_stateid");

            migrationBuilder.CreateIndex(
                name: "UQ__Profile__B7578BECA5F10BA7",
                table: "Profile",
                column: "profile_email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reply_profile_id",
                table: "Reply",
                column: "profile_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reply_topic_id",
                table: "Reply",
                column: "topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_category_id",
                table: "Topic",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_Topic_profile_id",
                table: "Topic",
                column: "profile_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorite");

            migrationBuilder.DropTable(
                name: "Reply");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "Dwelling");

            migrationBuilder.DropTable(
                name: "state");
        }
    }
}
