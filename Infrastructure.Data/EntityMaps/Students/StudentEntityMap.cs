using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain;

namespace Infrastructure.Data.EntityMaps.Students
{
    public class StudentEntityMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> _)
        {
            _.ToTable("Students");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name);
            _.Property(_ => _.NationalCode);
            _.Property(_ => _.PhoneNumber);
            _.HasMany(_ => _.Courses)
                .WithOne(_ => _.Student)
                .HasForeignKey(_ => _.StudentId);
        }
    }
}