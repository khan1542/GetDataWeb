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
        private string destinationConnectionString;

        //public DbSet<Parameter> Parameters { get; set; }
        //public DbSet<ParameterValue> ParameterValues { get; set; }
        public DbSet<SPModel> SPModels { get; set; }
        public DestinationDbContext(DbContextOptions<DestinationDbContext> options) : base(options) { }
    }
}
