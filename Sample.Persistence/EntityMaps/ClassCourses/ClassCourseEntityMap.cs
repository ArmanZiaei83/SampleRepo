using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain;

namespace Sample.Persistence.EntityMaps.ClassCourses
{
    public class ClassCourseEntityMap : IEntityTypeConfiguration<ClassCourse>
    {
        public void Configure(EntityTypeBuilder<ClassCourse> _)
        {
            _.ToTable("ClassCourses");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.ClassId);
            _.Property(_ => _.CourseId);
        }
    }
}