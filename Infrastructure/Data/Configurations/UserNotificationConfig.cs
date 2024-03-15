using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configurations
{
	internal class UserNotificationConfig : IEntityTypeConfiguration<UserNotification>
	{
		public void Configure(EntityTypeBuilder<UserNotification> builder)
		{
			builder.HasKey(x => x.Id);
			builder.ToTable("UserNotifications");
			builder.HasOne(x => x.TelegramChat).WithMany(x => x.UserNotifications).HasForeignKey(x => x.TelegramChatId).IsRequired(true);
			builder.HasOne(x => x.Notification).WithMany(x => x.UserNotifications).HasForeignKey(x => x.NotificationId).IsRequired(true);
		}
	}
}
