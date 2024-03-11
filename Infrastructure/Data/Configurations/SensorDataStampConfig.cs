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
