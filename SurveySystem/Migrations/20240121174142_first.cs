using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveySystem.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblKPI",
                columns: table => new
                {
                    KPIDNum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KPIDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DepNo = table.Column<int>(type: "int", nullable: false),
                    MeasurementUnit = table.Column<bool>(type: "bit", nullable: false),
                    TargetedValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblKPI", x => x.KPIDNum);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblKPI");
        }
    }
}
