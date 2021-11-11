using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SchoolSystem.Infrastructure.Migrations
{
    public partial class Initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_course_status",
                columns: table => new
                {
                    coursestatusid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    code = table.Column<string>(maxLength: 45, nullable: false),
                    description = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_course_status_pkey", x => x.coursestatusid);
                });

            migrationBuilder.CreateTable(
                name: "tb_rol",
                columns: table => new
                {
                    rolid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    name = table.Column<string>(maxLength: 45, nullable: false),
                    description = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_rol_pkey", x => x.rolid);
                });

            migrationBuilder.CreateTable(
                name: "tb_course",
                columns: table => new
                {
                    courseid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    code = table.Column<string>(maxLength: 45, nullable: false),
                    name = table.Column<string>(maxLength: 45, nullable: true),
                    coursestatusid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_course_pkey", x => x.courseid);
                    table.ForeignKey(
                        name: "tb_course_coursestatusid_fkey",
                        column: x => x.coursestatusid,
                        principalTable: "tb_course_status",
                        principalColumn: "coursestatusid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    userid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    nid = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 45, nullable: false),
                    lastname = table.Column<string>(maxLength: 45, nullable: true),
                    address = table.Column<string>(maxLength: 45, nullable: false),
                    phone = table.Column<string>(maxLength: 45, nullable: false),
                    username = table.Column<string>(maxLength: 45, nullable: false),
                    passsword = table.Column<string>(maxLength: 100, nullable: false),
                    rolid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_user_pkey", x => x.userid);
                    table.ForeignKey(
                        name: "tb_user_rolid_fkey",
                        column: x => x.rolid,
                        principalTable: "tb_rol",
                        principalColumn: "rolid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_student",
                columns: table => new
                {
                    studentid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    userid = table.Column<int>(nullable: true),
                    classroom = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_student_pkey", x => x.studentid);
                    table.ForeignKey(
                        name: "tb_student_userid_fkey",
                        column: x => x.userid,
                        principalTable: "tb_user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_teacher",
                columns: table => new
                {
                    teacherid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    userid = table.Column<int>(nullable: true),
                    subject = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_teacher_pkey", x => x.teacherid);
                    table.ForeignKey(
                        name: "tb_teacher_userid_fkey",
                        column: x => x.userid,
                        principalTable: "tb_user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tb_course_gradebook",
                columns: table => new
                {
                    coursegradebookid = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    studentid = table.Column<int>(nullable: true),
                    q1 = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    q2 = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    q3 = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    average = table.Column<decimal>(type: "numeric(3,2)", nullable: true),
                    teacherid = table.Column<int>(nullable: true),
                    courseid = table.Column<int>(nullable: true),
                    status = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("tb_course_gradebook_pkey", x => x.coursegradebookid);
                    table.ForeignKey(
                        name: "tb_course_gradebook_courseid_fkey",
                        column: x => x.courseid,
                        principalTable: "tb_course",
                        principalColumn: "courseid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tb_course_gradebook_studentid_fkey",
                        column: x => x.studentid,
                        principalTable: "tb_student",
                        principalColumn: "studentid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "tb_course_gradebook_teacherid_fkey",
                        column: x => x.teacherid,
                        principalTable: "tb_teacher",
                        principalColumn: "teacherid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_course_coursestatusid",
                table: "tb_course",
                column: "coursestatusid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_course_gradebook_courseid",
                table: "tb_course_gradebook",
                column: "courseid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_course_gradebook_studentid",
                table: "tb_course_gradebook",
                column: "studentid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_course_gradebook_teacherid",
                table: "tb_course_gradebook",
                column: "teacherid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_student_userid",
                table: "tb_student",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_teacher_userid",
                table: "tb_teacher",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_rolid",
                table: "tb_user",
                column: "rolid");

            migrationBuilder.CreateIndex(
                name: "tb_user_nid_username_key",
                table: "tb_user",
                columns: new[] { "nid", "username" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_course_gradebook");

            migrationBuilder.DropTable(
                name: "tb_course");

            migrationBuilder.DropTable(
                name: "tb_student");

            migrationBuilder.DropTable(
                name: "tb_teacher");

            migrationBuilder.DropTable(
                name: "tb_course_status");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_rol");
        }
    }
}
