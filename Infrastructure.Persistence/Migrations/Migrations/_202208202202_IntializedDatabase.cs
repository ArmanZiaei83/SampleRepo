using FluentMigrator;
using FluentMigrator.Builders;
using FluentMigrator.Expressions;

namespace Sample.Migrations.Migrations
{
    [Migration(202208202202)]
    public class _202208202202_IntializedDatabase : Migration
    {
        public override void Up()
        {
            CreateStudentsTable();

            CreateTeachersTable();

            CreateCoursesTable();

            CreateTeacherCoursesTable();

            CreateStudentCoursesTable();
        }

        public override void Down()
        {
            Delete.Table("StudentCourses");
            Delete.Table("TeacherCourese");
            Delete.Table("Courses");
            Delete.Table("Teachers");
            Delete.Table("Students");
        }

        private void CreateStudentsTable()
        {
            Create.Table("Students")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("NationalCode").AsString().NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable();
        }

        private void CreateTeachersTable()
        {
            Create.Table("Teachers")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("NationalCode").AsString().NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable();
        }

        private void CreateCoursesTable()
        {
            Create.Table("Courses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("StartDateTime").AsDateTime()
                .WithColumn("EndDateTime").AsDateTime()
                .WithColumn("StartTime").AsString()
                .WithColumn("EndTime").AsString();
        }

        private void CreateTeacherCoursesTable()
        {
            Create.Table("TeacherCourses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("TeacherId").AsInt32().NotNullable()
                .ForeignKey("FK_TeacherCourses_Teachers", "Teachers", "Id")
                .WithColumn("CourseId").AsInt32().NotNullable()
                .ForeignKey("FK_TeacherCourses_Courses", "Courses", "Id");
        }

        private void CreateStudentCoursesTable()
        {
            Create.Table("StudentCourses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("StudentId").AsInt32().NotNullable()
                .ForeignKey("FK_StudentCourses_Students", "Students", "Id")
                .WithColumn("CourseId").AsInt32().NotNullable()
                .ForeignKey("FK_StudentCourses_Courses", "Courses", "Id");
        }
    }
}