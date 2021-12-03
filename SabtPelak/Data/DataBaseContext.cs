using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SabtPelak.Entities;

namespace SabtPelak.Data
{
    public class DataBaseContext:DbContext
    {

        public DataBaseContext(DbContextOptions<DataBaseContext> op):base(op)
        {
            
        }

        public DbSet<tblCar> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var _Assembely = typeof(tblCarMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(_Assembely);

            base.OnModelCreating(modelBuilder);
        }
    }
}
