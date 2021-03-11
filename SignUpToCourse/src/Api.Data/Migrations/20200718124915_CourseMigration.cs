using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class CourseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    NumberOfStudents = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SignUpToCourse",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    CourseId = table.Column<string>(nullable: false),
                    StudentEmail = table.Column<string>(maxLength: 60, nullable: false),
                    StudentName = table.Column<string>(maxLength: 60, nullable: false),
                    StudentAge = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignUpToCourse", x => x.Id);
                });

                
            migrationBuilder.CreateTable(
                name: "CourseStatistics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    CourseId = table.Column<string>(nullable: false),
                    MinimumAge = table.Column<int>(nullable: false),
                    MaximumAge = table.Column<int>(nullable: false),
                    AverageAge = table.Column<decimal>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStatistics", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Name", "Capacity", "NumberOfStudents", "CreateAt", "UpdateAt"},
                values: new object[] { new Guid("ef256aac-2b6e-48e5-a598-814a1e468b65"),  "Java", 5, 0, new DateTime(2020, 7, 18, 9, 49, 14, 477, DateTimeKind.Local).AddTicks(1482),new DateTime(2020, 7, 18, 9, 49, 14, 477, DateTimeKind.Local).AddTicks(9678) });
            
         }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");
                  migrationBuilder.DropTable(
                name: "SignUpToCourse");
                 migrationBuilder.DropTable(
                name: "CourseStatistics");
        }
    }
}
