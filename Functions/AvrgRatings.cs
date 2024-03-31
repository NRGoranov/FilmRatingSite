#r "System.Data.SqlClient"

using System;
using System.Data.SqlClient;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

public static void Run([TimerTrigger("0 30 11 * * *")]TimerInfo myTimer, ILogger log)
{
    var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
    
    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        var text = "UPDATE Movies SET AverageRating = (SELECT AVG(Rating) FROM Reviews WHERE MovieID = Movies.MovieID) WHERE MovieID IN (SELECT MovieID FROM Reviews)";
        
        using (var cmd = new SqlCommand(text, conn))
        {
            cmd.ExecuteNonQuery();
        }
    }

    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
}
