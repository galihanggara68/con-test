using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ConTestWeb.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConTestWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _config;

        public WeatherForecastController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public List<string> GetUsers()
        {
            Connector con = new Connector(_config.GetValue<string>("ConString"));
            List<string> ret = new List<string>();
            SqlConnection connection = con.GetConnection();
            connection.Open();
            try
            {
                SqlCommand query = new SqlCommand("select EMAIL_ from ACT_ID_USER", connection);
                SqlDataReader reader = query.ExecuteReader();
                while (reader.Read())
                {
                    ret.Add(reader["EMAIL_"].ToString());
                }
            }
            catch(SqlException e)
            {
                Console.WriteLine(e.Message);
            }
            connection.Close();
            return ret;
        }
    }
}
