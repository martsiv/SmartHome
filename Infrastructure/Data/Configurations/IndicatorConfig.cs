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
	internal class IndicatorConfig : IEntityTypeConfiguration<Indicator>
	{
		public void Configure(EntityTypeBuilder<Indicator> builder)
		{
			builder.HasKey(x => x.Id);
			builder.ToTable("Indicators");
		}
	}
}
