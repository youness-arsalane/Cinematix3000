using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cinematix3000.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinema",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    HouseNumber = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinema", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    BirthDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Director = table.Column<string>(nullable: true),
                    Cast = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Runtime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Venue_Cinema_CinemaID",
                        column: x => x.CinemaID,
                        principalTable: "Cinema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VenueMovie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieID = table.Column<int>(nullable: false),
                    VenueID = table.Column<int>(nullable: false),
                    StartDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueMovie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VenueMovie_Movie_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VenueMovie_Venue_VenueID",
                        column: x => x.VenueID,
                        principalTable: "Venue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(nullable: false),
                    VenueMovieID = table.Column<int>(nullable: false),
                    SeatNumber = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_VenueMovie_VenueMovieID",
                        column: x => x.VenueMovieID,
                        principalTable: "VenueMovie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });;

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientID",
                table: "Reservation",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_VenueMovieID",
                table: "Reservation",
                column: "VenueMovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Venue_CinemaID",
                table: "Venue",
                column: "CinemaID");

            migrationBuilder.CreateIndex(
                name: "IX_VenueMovie_MovieID",
                table: "VenueMovie",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_VenueMovie_VenueID",
                table: "VenueMovie",
                column: "VenueID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "VenueMovie");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropTable(
                name: "Cinema");
        }
    }
}
