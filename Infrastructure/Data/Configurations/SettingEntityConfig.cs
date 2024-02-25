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
