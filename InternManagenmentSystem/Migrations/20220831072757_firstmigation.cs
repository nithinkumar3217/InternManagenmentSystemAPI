using Microsoft.EntityFrameworkCore.Migrations;

namespace InternManagenmentSystem.Migrations
{
    public partial class firstmigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternDesignation",
                columns: table => new
                {
                    SNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationId = table.Column<int>(nullable: false),
                    DesignationName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    DepartMent = table.Column<string>(type: "nvarchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternDesignation", x => x.SNo);
                });

            migrationBuilder.CreateTable(
                name: "InternLeaveRequest",
                columns: table => new
                {
                    SNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternId = table.Column<int>(nullable: false),
                    InternName = table.Column<string>(nullable: true),
                    LeaveDate = table.Column<string>(nullable: false),
                    LeaveReason = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    LeaveType = table.Column<string>(type: "nvarchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternLeaveRequest", x => x.SNo);
                });

            migrationBuilder.CreateTable(
                name: "InternWorkingHour",
                columns: table => new
                {
                    SNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternId = table.Column<int>(nullable: false),
                    CompanyMonthlyWorkingHours = table.Column<int>(nullable: false),
                    InternMonthlyWorkingHours = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternWorkingHour", x => x.SNo);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    SNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.SNo);
                });

            migrationBuilder.CreateTable(
                name: "Registers",
                columns: table => new
                {
                    SNo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registers", x => x.SNo);
                });

            migrationBuilder.CreateTable(
                name: "InternRecord",
                columns: table => new
                {
                    InternId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InternName = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    InternDesignationSNo = table.Column<int>(nullable: true),
                    DesigntionId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternRecord", x => x.InternId);
                    table.ForeignKey(
                        name: "FK_InternRecord_InternDesignation_InternDesignationSNo",
                        column: x => x.InternDesignationSNo,
                        principalTable: "InternDesignation",
                        principalColumn: "SNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternRecord_InternDesignationSNo",
                table: "InternRecord",
                column: "InternDesignationSNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternLeaveRequest");

            migrationBuilder.DropTable(
                name: "InternRecord");

            migrationBuilder.DropTable(
                name: "InternWorkingHour");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Registers");

            migrationBuilder.DropTable(
                name: "InternDesignation");
        }
    }
}
