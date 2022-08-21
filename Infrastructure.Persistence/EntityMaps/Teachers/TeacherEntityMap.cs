using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain.Entities;

namespace Infrastructure.Persistence.EntityMaps.Teachers
{
    public class TeacherEntityMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> _)
        {
            _.ToTable("Teachers");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name);
            _.Property(_ => _.NationalCode);
            _.Property(_ => _.PhoneNumber);
            _.HasMany(_ => _.Courses)
                .WithOne(_ => _.Teacher)
                .HasForeignKey(_ => _.TeacherId);
        }
    }
}