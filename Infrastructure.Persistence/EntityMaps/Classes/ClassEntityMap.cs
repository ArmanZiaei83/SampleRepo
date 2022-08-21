using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain;
using Sample.Domain.Entities;

namespace Infrastructure.Persistence.EntityMaps.Classes
{
    public class ClassEntityMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> _)
        {
            _.ToTable("Classes");
            _.HasKey(_ => _.Id);
            _.Property(_ => _.Id).ValueGeneratedOnAdd();
            _.Property(_ => _.Name);
            _.HasMany(_ => _.Courses)
                .WithOne(_ => _.Class)
                .HasForeignKey(_ => _.ClassId);
        }
    }
}