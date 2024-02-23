using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_access.Data.Entities;

namespace Data_access.Data.Configurations
{
    internal class ControllsHistoryEntityConfig : IEntityTypeConfiguration<ControllsHystory>
    {
        public void Configure(EntityTypeBuilder<ControllsHystory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("ControllsHystories");
            builder.HasOne(x => x.Sensor).WithMany(x => x.ControllsHystories).HasForeignKey(x => x.SensorId).IsRequired(true);
            builder.HasOne(x => x.User).WithMany(x => x.ControllsHystories).HasForeignKey(x => x.UserId).IsRequired(true);
            builder.HasOne(x => x.Command).WithMany(x => x.ControllsHystories).HasForeignKey(x => x.CommandId).IsRequired(true);
        }
    }
}
