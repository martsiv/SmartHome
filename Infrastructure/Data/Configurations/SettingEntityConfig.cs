using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
	internal class SettingEntityConfig : IEntityTypeConfiguration<Setting>
	{
		public void Configure(EntityTypeBuilder<Setting> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Value).HasColumnType("decimal(18,4)");
			builder.ToTable("Settings");
		}
	}
}
