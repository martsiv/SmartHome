using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
	internal class SensorTypeEntityConfig : IEntityTypeConfiguration<SensorType>
    {
        public void Configure(EntityTypeBuilder<SensorType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("SensorTypes");
        }
    }
}
