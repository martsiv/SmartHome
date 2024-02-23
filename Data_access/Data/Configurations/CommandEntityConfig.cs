﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_access.Data.Entities;

namespace Data_access.Data.Configurations
{
    internal class CommandEntityConfig : IEntityTypeConfiguration<Command>
    {
        public void Configure(EntityTypeBuilder<Command> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Commands");
        }
    }
}
