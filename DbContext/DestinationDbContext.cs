using GetDataFromDBApp.Models;
using GetDataWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GetDataFromDBAppDbContext.Migrations
{
    public class DestinationDbContext : DbContext
    {
        public DbSet<Pech> Pechi { get; set; }

        public DbSet<Parameter> Parameters { get; set; }

        public DbSet<ParameterValue> ParameterValues { get; set; }

        public DestinationDbContext(DbContextOptions<DestinationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParameterValue>().HasKey(u => new { u.PechId, u.ParameterId, u.DtFirstDay });

            modelBuilder.Entity<Pech>().HasData(
                new Pech { PechId = 1, Name = "ДП-1" },
                new Pech { PechId = 2, Name = "ДП-2" },
                new Pech { PechId = 4, Name = "ДП-4" },
                new Pech { PechId = 6, Name = "ДП-6" },
                new Pech { PechId = 7, Name = "ДП-7" },
                new Pech { PechId = 8, Name = "ДП-8" },
                new Pech { PechId = 9, Name = "ДП-9" },
                new Pech { PechId = 10, Name = "ДП-10" },
                new Pech { PechId = 255, Name = "Цех" }
            );
        }
    }
}
