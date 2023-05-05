using GetDataFromDBAppDbContext.Migrations;
using GetDataWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using GetDataFromDBApp.Models;

namespace GetDataWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly SourceDBContext _sourceContext;
        
        private readonly DestinationDbContext _destinationContext;

        public HomeController(SourceDBContext sourceContext, DestinationDbContext destinationContext)
        {
            _sourceContext = sourceContext;
            _destinationContext = destinationContext;
        }
        
        public async Task<ActionResult> Index()
        {
            // Получить результаты хранимки используя FromSqlInterpolated 
            var year = 0;
            var dt = new DateTime(2017, 1, 1);

            var parameters = await _destinationContext.Parameters.ToListAsync();

            List<SPModel>  reportResults = await _sourceContext.SPModels
                .FromSqlInterpolated($"EXEC dbo.monthReport_0007_TechnReport_BODY @dt = {dt}, @year = {year}")
                .ToListAsync();

            var pechi = await _destinationContext.Pechi.ToListAsync();

            foreach(var row in  reportResults)
            {
                var parameterName = row.Descr.TrimEnd();
                var parameter = parameters.FirstOrDefault(x => x.Name == parameterName);

                if (parameter == null)
                {
                    parameter = new Parameter { Name = parameterName };
                    await _destinationContext.Parameters.AddAsync(parameter);
                    await _destinationContext.SaveChangesAsync();
                }

                foreach(var pech in pechi)
                {
                    double? parameterValue = null;
                    var value = typeof(SPModel).GetProperty("sDP" + pech.PechId.ToString())?.GetValue(row);

                    if (value != null)
                    {
                        double.TryParse(value.ToString().Replace('.', ','), out double doubleValue);
                        parameterValue = doubleValue;
                    }

                    await _destinationContext.ParameterValues.AddAsync(new ParameterValue
                    {
                        DtFirstDay = dt,
                        ParameterId = parameter.ParameterId,
                        PechId = pech.PechId,
                        Value = parameterValue
                    });
                }
            }
            await _destinationContext.SaveChangesAsync();
            
            return View(reportResults);
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

        private double? GetDoubleValue(string value)
        {
            if (!double.TryParse(value.Trim().Replace('.', ','), out double result)) return null;

            return result;
        }
    }
}