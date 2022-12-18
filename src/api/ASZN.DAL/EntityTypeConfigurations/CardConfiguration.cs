using ASZN.DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASZN.DAL.EntityTypeConfigurations
{
    internal class CardConfiguration : BaseEntityConfiguration<Card>
    {
        public override void Configure(EntityTypeBuilder<Card> builder)
        {
            base.Configure(builder);

            builder.Property(_ => _.CardNumber)
                .HasMaxLength(16)
                .IsRequired();
        }
    }
}
