using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
	internal class NotificationEntityConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Notifications");
            builder.HasOne(x => x.Sensor).WithMany(x => x.Notifications).HasForeignKey(x => x.SensorId).IsRequired(true);
			builder.Property(x => x.Data).HasColumnType("decimal(18,4)");
		}
	}
}
