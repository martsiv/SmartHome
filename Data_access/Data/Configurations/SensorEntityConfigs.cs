﻿using Data_access.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data_access.Data.Configurations
{
    internal class SensorEntityConfigs : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Sensors");
            builder.HasOne(x => x.SensorType).WithMany(x => x.Sensors).HasForeignKey(x => x.SensorTypeId).IsRequired(false);
            builder.HasOne(x => x.Room).WithMany(x => x.Sensors).HasForeignKey(x => x.RoomId).IsRequired(true);
            builder.HasOne(x => x.State).WithMany(x => x.Sensors).HasForeignKey(x => x.StateId).IsRequired(false).OnDelete(DeleteBehavior.SetNull);
        }
    }
}
