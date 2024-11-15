using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Seed_AddingBaseEngineersAndLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO tb_engineer VALUES
                ('Engineer 1'),
                ('Engineer 2')

                INSERT INTO tb_location VALUES
                ('The Winchester', null, null),
                ('The Worlds End', null, null),
                ('The Crown', null, null),
                ('Cornetto Inn', null, null)
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
