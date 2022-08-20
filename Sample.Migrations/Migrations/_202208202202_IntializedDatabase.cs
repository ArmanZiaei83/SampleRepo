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

            CreateClassesTable();

            CreateClassCoursesTable();
        }

        public override void Down()
        {
            Delete.Table("ClassCourses");
            Delete.Table("Classes");
            Delete.Table("StudentCourses");
            Delete.Table("TeacherCourese");
            Delete.Table("Courses");
            Delete.Table("Teachers");
            Delete.Table("Students");
        }

        private void CreateClassCoursesTable()
        {
            Create.Table("ClassCourses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("ClassId").AsInt32().NotNullable()
                .ForeignKey("FK_ClassCourses_Classes", "Classes", "Id")
                .WithColumn("CourseId").AsInt32().NotNullable()
                .ForeignKey("FK_ClassCourses_Courses", "Courses", "Id");
        }

        private void CreateClassesTable()
        {
            Create.Table("Classes")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable();
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

        private void CreateTeacherCoursesTable()
        {
            Create.Table("TeacherCourses")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("TeacherId").AsInt32().NotNullable()
                .ForeignKey("FK_TeacherCourses_Teachers", "Teachers", "Id")
                .WithColumn("CourseId").AsInt32().NotNullable()
                .ForeignKey("FK_TeacherCourses_Courses", "Courses", "Id");
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

        private void CreateTeachersTable()
        {
            Create.Table("Teachers")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("NationalCode").AsString().NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable();
        }

        private void CreateStudentsTable()
        {
            Create.Table("Students")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("NationalCode").AsString().NotNullable()
                .WithColumn("PhoneNumber").AsString().NotNullable();
        }
    }
}