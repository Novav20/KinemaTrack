using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KinemaTrack.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddJointEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Joints",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    JointNumber = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Angle = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    LinkLength = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    RobotArmId = table.Column<Guid>(type: "RAW(16)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Joints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Joints_RobotArms_RobotArmId",
                        column: x => x.RobotArmId,
                        principalTable: "RobotArms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Joints_RobotArmId",
                table: "Joints",
                column: "RobotArmId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Joints");
        }
    }
}
