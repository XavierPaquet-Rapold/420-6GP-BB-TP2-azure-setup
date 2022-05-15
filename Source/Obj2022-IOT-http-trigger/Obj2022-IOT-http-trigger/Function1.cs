using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Obj2022_IOT_http_trigger
{
    public static class Function1
    {
        [FunctionName("GetLastConstantEntry")]
        public static IActionResult GetLastConstantEntry(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetLastConstantEntry")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Request GetLastConstantEntry");
            var dataTable = new DataTable();
            try
            {
                using(var connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = "SELECT TOP 1 * FROM [dbo].[constants] ORDER BY EventProcessedUtcTime DESC";
                    var command = new SqlCommand(query, connection);
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception wException)
            {
                log.LogError(wException.Message);
            }

            if (dataTable.Rows.Count == 0)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(dataTable);
        }

        [FunctionName("GetLastDistanceTemperatureEntry")]
        public static IActionResult GetLastDistanceTemperatureEntry(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetLastDistanceTemperatureEntry")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Request GetLastDistanceTemperatureEntry");
            var dataTable = new DataTable();
            try
            {
                using (var connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = "SELECT TOP 1 * FROM [dbo].[distance_temperature] ORDER BY EventProcessedUtcTime DESC";
                    var command = new SqlCommand(query, connection);
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception wException)
            {
                log.LogError(wException.Message);
            }

            if (dataTable.Rows.Count == 0)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(dataTable);
        }

        [FunctionName("GetLastMotorEntry")]
        public static IActionResult GetLastMotorEntry(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetLastMotorEntry")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Request GetLastMotorEntry");
            var dataTable = new DataTable();
            try
            {
                using (var connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = "SELECT TOP 1 * FROM [dbo].[motor] ORDER BY EventProcessedUtcTime DESC";
                    var command = new SqlCommand(query, connection);
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception wException)
            {
                log.LogError(wException.Message);
            }

            if (dataTable.Rows.Count == 0)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(dataTable);
        }

        [FunctionName("GetAllDistanceTemperature")]
        public static IActionResult GetAllDistanceTemperature(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetAllDistanceTemperature")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Request GetAllDistanceTemperature");
            var dataTable = new DataTable();
            try
            {
                using (var connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = @"SELECT * FROM [dbo].[distance_temperature] ORDER BY EventProcessedUtcTime DESC";
                    var command = new SqlCommand(query, connection);
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception wException)
            {
                log.LogError(wException.Message);
            }

            if (dataTable.Rows.Count == 0)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(dataTable);
        }

        [FunctionName("GetControlData")]
        public static IActionResult GetControlData(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetControlData")] HttpRequest req, ILogger log)
        {
            log.LogInformation("Request GetControlData");
            var dataTable = new DataTable();
            try
            {
                using (var connection = new SqlConnection(Environment.GetEnvironmentVariable("SqlConnectionString")))
                {
                    connection.Open();
                    var query = @"SELECT TOP 1 * FROM [dbo].[control] ORDER BY EventProcessedUtcTime DESC";
                    var command = new SqlCommand(query, connection);
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);
                }
            }
            catch (Exception wException)
            {
                log.LogError(wException.Message);
            }

            if (dataTable.Rows.Count == 0)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(dataTable);
        }

    }
}
