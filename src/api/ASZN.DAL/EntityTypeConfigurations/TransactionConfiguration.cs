using ASZN.DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASZN.DAL.EntityTypeConfigurations
{
    internal class TransactionConfiguration : BaseEntityConfiguration<Transaction>
    {
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            base.Configure(builder);

            builder.HasOne(_ => _.Vendor)
                .WithMany(_ => _.Transactions)
                .HasForeignKey(a => a.VendorId);

            builder.HasOne(_ => _.Card)
                .WithMany()
                .HasForeignKey(a => a.CardId);
        }
    }
}
