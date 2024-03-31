#r "Newtonsoft.Json"
#r "System.Data.SqlClient"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    string title = req.Query["title"];
    
    var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
    var sb = new StringBuilder();
    
    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        var cmdText = $"SELECT * FROM Movies WHERE Title LIKE '%{title}%'";

        using (var cmd = new SqlCommand(cmdText, conn))
        {
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    sb.AppendLine($"Title: {reader["Title"]}, Average Rating: {reader["AverageRating"]}");
                }
            }
        }
    }

    return new OkObjectResult(sb.ToString());
}
