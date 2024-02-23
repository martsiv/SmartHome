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
    internal class ValueNameEntityConfig : IEntityTypeConfiguration<ValueName>
    {
        public void Configure(EntityTypeBuilder<ValueName> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("ValueNames");
        }
    }
}
