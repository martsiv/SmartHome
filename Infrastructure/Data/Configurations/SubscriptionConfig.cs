using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
	internal class SubscriptionConfig : IEntityTypeConfiguration<Subscription>
	{
		public void Configure(EntityTypeBuilder<Subscription> builder)
		{
			builder.HasKey(x => x.Id);
			builder.ToTable("Subscriptions");
			builder.HasOne(x => x.TelegramChat).WithMany(x => x.Subscriptions).HasForeignKey(x => x.TelegramChatId).IsRequired(true);
			builder.HasOne(x => x.Notification).WithMany(x => x.Subscriptions).HasForeignKey(x => x.NotificationId).IsRequired(true);
		}
	}
}
