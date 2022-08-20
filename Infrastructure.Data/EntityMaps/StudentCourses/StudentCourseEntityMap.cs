using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain;

namespace Infrastructure.Data.EntityMaps.StudentCourses
{
    public class StudentCourseEntityMap : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> _)
        {
            _.ToTable("StudentCourses");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.CourseId);
            _.Property(_ => _.StudentId);
        }
    }
}