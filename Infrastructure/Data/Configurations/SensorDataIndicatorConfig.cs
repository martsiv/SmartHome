using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
	internal class SensorDataIndicatorConfig : IEntityTypeConfiguration<SensorDataIndicator>
	{
		public void Configure(EntityTypeBuilder<SensorDataIndicator> builder)
		{
			builder.HasKey(x => x.Id);
			builder.ToTable("SensorDataIndicators");
			builder.HasOne(x => x.Indicator).WithMany(x => x.SensorDataIndicators).HasForeignKey(x => x.IndicatorId).IsRequired(true);
			builder.HasOne(x => x.SensorData).WithMany(x => x.SensorDataIndicators).HasForeignKey(x => x.SensorDataId).IsRequired(true);
			builder.Property(x => x.Value).HasColumnType("decimal(18,4)");
		}
	}
}
