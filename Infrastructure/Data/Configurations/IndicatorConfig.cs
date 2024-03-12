using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
	internal class IndicatorConfig : IEntityTypeConfiguration<Indicator>
	{
		public void Configure(EntityTypeBuilder<Indicator> builder)
		{
			builder.HasKey(x => x.Id);
			builder.ToTable("Indicators");
		}
	}
}
