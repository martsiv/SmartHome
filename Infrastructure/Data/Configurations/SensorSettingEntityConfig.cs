using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;

namespace Infrastructure.Data.Configurations
{
	internal class SensorSettingEntityConfig : IEntityTypeConfiguration<SensorSetting>
	{
		public void Configure(EntityTypeBuilder<SensorSetting> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Sensor).WithMany(x => x.SensorSettings).HasForeignKey(x => x.SensorId).IsRequired(true);
			builder.HasOne(x => x.Setting).WithMany(x => x.SensorSettings).HasForeignKey(x => x.SettingId).IsRequired(true);
			builder.ToTable("SensorSettings");
		}
	}
}
