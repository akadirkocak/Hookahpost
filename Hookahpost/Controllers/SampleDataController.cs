using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hookahpost.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public JsonResult WeatherForecasts2()
        {
            JsonResult categoryJson = new JsonResult("deneme");
            return categoryJson;
        }

        // Hellooopo


        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }
            public string Demo { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        [HttpPost("[action]")]
        public void Post([FromBody] dynamic value)
        {
            List<string> list = new List<string>();
            foreach(string a in value)
            {
                
                list.Add(a);
            }
            string uName = list[0], uPassword = list[1];
            string connectionString = @"Data Source=77.245.159.10\MSSQLSERVER2014;Initial Catalog=hookahpostDb; User Id=hookahpostUser;Password=s.a.5050;";
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("INSERT INTO Users (FirstName, Password,Active) values ('asd','sdsa',1)", sqlCon);
                string query = "INSERT INTO Users (FirstName, Password,Active) values ('"+uName+"','"+uPassword+"',1)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
        }
    }
}
