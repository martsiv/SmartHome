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
	internal class TelegramChatConfig : IEntityTypeConfiguration<TelegramChatEntity>
	{
		public void Configure(EntityTypeBuilder<TelegramChatEntity> builder)
		{
			builder.HasKey(x => x.Id);
			builder.ToTable("TelegramChats");
			builder.HasAlternateKey(x => x.ChatId);
			builder.Property(x => x.ChatId)
				.HasColumnType("bigint")
				.IsRequired(true);
			builder.Property(x => x.FirstName).HasMaxLength(255);
			builder.Property(x => x.LastName).HasMaxLength(255);
			builder.Property(x => x.Username).HasMaxLength(255);
		}
	}
}
