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
    }
}