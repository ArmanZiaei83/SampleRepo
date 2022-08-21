using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain;
using Sample.Domain.Entities;

namespace Infrastructure.Persistence.EntityMaps.Courses
{
    public class CourseEntityMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> _)
        {
            _.ToTable("Courses");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name);
            _.Property(_ => _.EndTime);
            _.Property(_ => _.StartTime);
            _.Property(_ => _.EndDateTime);
            _.Property(_ => _.StartDateTime);
            _.HasMany(_ => _.Classes)
                .WithOne(_ => _.Course)
                .HasForeignKey(_ => _.CourseId);
            _.HasMany(_ => _.Students)
                .WithOne(_ => _.Course)
                .HasForeignKey(_ => _.CourseId);
            _.HasMany(_ => _.Teachers)
                .WithOne(_ => _.Course)
                .HasForeignKey(_ => _.CourseId);
        }
    }
}