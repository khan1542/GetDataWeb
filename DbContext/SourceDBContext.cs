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
    public class SourceDBContext : DbContext
    {
        private string connectionString;

        public DbSet<SPModel> SPModels { get; set; }
        public SourceDBContext(DbContextOptions<SourceDBContext> options) : base(options) { }

    }
}
