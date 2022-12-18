using ASZN.DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASZN.DAL.EntityTypeConfigurations
{
    internal abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(_ => _.Id);

            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        }
    }
}
