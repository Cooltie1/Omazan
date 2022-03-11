using Microsoft.EntityFrameworkCore.Migrations;

namespace Omazan.Migrations
{
    public partial class addShippedField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<bool>(
                name: "shipped",
                table: "Purchases",
                nullable: false,
                defaultValue: false);

      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "shipped",
                table: "Purchases");

        
        }
    }
}
