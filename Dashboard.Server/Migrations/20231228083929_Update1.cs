using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Server.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE EmployeesDatas SET EmployeeImage = CONVERT(varbinary(max), EmployeeImage)");
            migrationBuilder.AlterColumn<byte[]>(
                name: "EmployeeImage",
                table: "EmployeesDatas",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "nvarchar(max)",
                oldNullable: true,
                defaultValue: new byte[] { },
                oldDefaultValueSql: "0x");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
