using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain;

namespace Sample.Persistence.EntityMaps.TeacherCourses
{
    public class TeacherCourseEntityMap : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> _)
        {
            _.ToTable("TeacherCourses");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.CourseId);
            _.Property(_ => _.TeacherId);
        }
    }
}