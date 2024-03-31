#r "Newtonsoft.Json"
#r "System.Data.SqlClient"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Data.SqlClient;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    var review = JsonConvert.DeserializeObject<Review>(requestBody);
    
    var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
    
    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        var text = "INSERT INTO Reviews (MovieID, Opinion, Rating, Date, Author) VALUES (@MovieID, @Opinion, @Rating, @Date, @Author)";
        
        using (var cmd = new SqlCommand(text, conn))
        {
            cmd.Parameters.AddWithValue("@MovieID", review.MovieID);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    return new OkObjectResult("Review added");
}

public class Review
{
    public int MovieID { get; set; }
}
