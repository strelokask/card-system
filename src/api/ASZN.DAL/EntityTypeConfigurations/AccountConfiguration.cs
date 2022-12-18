using ASZN.DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASZN.DAL.EntityTypeConfigurations
{
    internal class AccountConfiguration : BaseEntityConfiguration<Account>
    {
        public override void Configure(EntityTypeBuilder<Account> builder)
        {
            base.Configure(builder);

            builder.HasOne(_ => _.User)
                .WithMany(_ => _.Accounts)
                .HasForeignKey(a => a.UserId);
        }
    }
}
