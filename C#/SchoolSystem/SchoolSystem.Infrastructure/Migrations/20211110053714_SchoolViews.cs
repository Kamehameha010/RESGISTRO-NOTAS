using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolSystem.Infrastructure.Migrations
{
    public partial class SchoolViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string studentUserQuery = @"
                CREATE OR REPLACE VIEW VWStudentUser
                AS
                SELECT tu.userid,
                    tu.nid,
                    tu.name,
                    tu.lastname,
                    tu.address,
                    tu.phone,
                    tu.username,
                    tu.passsword,
                    tu.rolid,
                    ts.studentid,
                    ts.classroom
                FROM tb_user tu
                    JOIN tb_student ts ON tu.userid = ts.userid;
            ";
            string teacherUserQuery = @"
                CREATE OR REPLACE VIEW VWTeacherUser
                AS
                SELECT tu.userid,
                    tu.nid,
                    tu.name,
                    tu.lastname,
                    tu.address,
                    tu.phone,
                    tu.username,
                    tu.passsword,
                    tu.rolid,
                    ttc.teacherid,
                    ttc.subject
                FROM tb_user tu
                    JOIN tb_teacher ttc ON tu.userid = ttc.userid;
            "; ;

           
            migrationBuilder.Sql(studentUserQuery);
            migrationBuilder.Sql(teacherUserQuery);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW VWStudentUser");
            migrationBuilder.Sql(@"DROP VIEW VWTeacherUser");
            migrationBuilder.Sql(@"DROP VIEW VWGradebook");
        }
    }
}
