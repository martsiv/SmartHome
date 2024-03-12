using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
	internal class SensorDataStampConfig : IEntityTypeConfiguration<SensorDataStamp>
	{
		public void Configure(EntityTypeBuilder<SensorDataStamp> builder)
		{
			builder.HasKey(x => x.Id);
			builder.ToTable("SensorDataStamps");
			builder.HasOne(x => x.Sensor).WithMany(x => x.SensorDataStamps).HasForeignKey(x => x.SensorId).IsRequired(true);
		}
	}
}
