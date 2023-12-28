using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dashboard.Server.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.AlterColumn<string>(
                name: "EmployeeImage",
                table: "EmployeesDatas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }
    }
}
