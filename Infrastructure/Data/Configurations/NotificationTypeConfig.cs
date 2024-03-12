using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
	internal class NotificationTypeConfig : IEntityTypeConfiguration<NotificationType>
	{
		public void Configure(EntityTypeBuilder<NotificationType> builder)
		{
			builder.HasKey(x => x.Id);
			builder.ToTable("NotificationTypes");
		}
	}
}
