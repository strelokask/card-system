using ASZN.DomainModel;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ASZN.DAL.EntityTypeConfigurations
{
    internal class VendorConfiguration : BaseEntityConfiguration<Vendor>
    {
        public override void Configure(EntityTypeBuilder<Vendor> builder)
        {
            base.Configure(builder);
        }
    }
}
