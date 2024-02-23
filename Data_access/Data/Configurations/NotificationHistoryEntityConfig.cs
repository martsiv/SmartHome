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
    internal class NotificationHistoryEntityConfig : IEntityTypeConfiguration<NotificationHistory>
    {
        public void Configure(EntityTypeBuilder<NotificationHistory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("NotificationHistories");
            builder.HasOne(x => x.Sensor).WithMany(x => x.NotificationHistories).HasForeignKey(x => x.SensorId).IsRequired(true);
            builder.HasOne(x => x.ValueName).WithMany(x => x.NotificationHistories).HasForeignKey(x => x.ValueNameId).IsRequired(true);
        }
    }
}
