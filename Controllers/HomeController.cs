using GetDataFromDBAppDbContext.Migrations;
using GetDataWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Collections.Generic;

namespace GetDataWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly SourceDBContext _sourceContext;
        private readonly DestinationDbContext _destinationContext;

        //public DestinationDbContext DestinationContext => _destinationContext;

        //public SourceDBContext SourceContext => _sourceContext;

        public HomeController(SourceDBContext sourceContext, DestinationDbContext destinationContext)
        {
            _sourceContext = sourceContext;
            _destinationContext = destinationContext;
        }
        
        public async Task<ActionResult> Index()
        {
            //connection string для БД с хранимкой
            string connectionString = "Server=DESKTOP-IGTK1UR;Database=Report;Trusted_Connection=True;TrustServerCertificate=true;";
            string destinationConnectionString = "Server=DESKTOP-IGTK1UR;Database=SPParameters;Trusted_Connection=True;TrustServerCertificate=true;";
            var reportResults = new List<SPModel>();

            using (var sourceDbContext = new SourceDBContext(connectionString))
            using (var destinationDbContext = new DestinationDbContext())
            {
                // Получить результаты хранимки используя FromSqlInterpolated 
                var year = 0;
                var dt = "2018.01.01";
                reportResults = await sourceDbContext.SPModels
                    .FromSqlInterpolated(($"EXEC dbo.monthReport_0007_TechnReport_BODY @dt='{dt}', @year={year}"))
                    .ToListAsync();

                // Записать результаты в  DestinationDbContext
                destinationDbContext.SPModels.AddRange(reportResults);

                await destinationDbContext.SaveChangesAsync();
            }

            return View();
        }

        //public IActionResult Index()
        //{
        //    string connectionString = "Server=DESKTOP-IGTK1UR;Database=Report;Trusted_Connection=True;";

        //    using (GetDataFromDBAppContext db = new GetDataFromDBAppContext())
        //    {
        //        var year = 0;
        //        var dt = "'2018.01.01'";
        //        var spModel = db.SPModels.FromSqlInterpolated($"EXEC dbo.monthReport_0007_TechnReport_BODY @dt={dt}, @year={year}").ToList();
        //        foreach (var spmodel in spModel)
        //            Console.WriteLine(spmodel.Descr);
        //    }

        //    // List<Parameter> GetMyDataFromStoredProcedure()
        //    //{
        //    //    string sqlExpression = "monthReport_0007_TechnReport_BODY";

        //    //    List<Parameter> myData = new List<Parameter>();

        //    //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    //    {
        //    //        SqlCommand cmd = new SqlCommand(sqlExpression, conn);
        //    //        cmd.CommandType = CommandType.StoredProcedure;
        //    //        cmd.Parameters.Add(new SqlParameter("@dt", "2018.01.01"));
        //    //        cmd.Parameters.Add(new SqlParameter("@year", 0));

        //    //        conn.Open();

        //    //        string GUID = Guid.NewGuid().ToString();

        //    //        using (SqlDataReader reader = cmd.ExecuteReader())
        //    //        {
        //    //            while (reader.Read())
        //    //            {
        //    //                Parameter model = new Parameter();
        //    //                model.ID_Parameter = Convert.ToString(GUID);
        //    //                model.ParameterName = Convert.ToString(reader["Descr"]);

        //    //                myData.Add(model);
        //    //            }
        //    //        }
        //    //    }

        //    //    return myData;
        //    //}

        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}