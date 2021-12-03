using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SabtPelak.Entities;

namespace SabtPelak.Data
{
    public class tblCarMapping:IEntityTypeConfiguration<tblCar>
    {
        public void Configure(EntityTypeBuilder<tblCar> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Pelak).IsRequired().HasMaxLength(13);
            builder.Property(c => c.Color).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Year).IsRequired().HasMaxLength(50);

        }
    }
}
