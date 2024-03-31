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
    var movie = JsonConvert.DeserializeObject<Movie>(requestBody);
    
    var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
    
    using (var conn = new SqlConnection(connectionString))
    {
        conn.Open();
        var text = "INSERT INTO Movies (Title, Year, Genre, Description, Director, Actors) VALUES (@Title, @Year, @Genre, @Description, @Director, @Actors)";
        
        using (var cmd = new SqlCommand(text, conn))
        {
            cmd.Parameters.AddWithValue("@Title", movie.Title);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    return new OkObjectResult("Movie added");
}

public class Movie
{
    public string Title { get; set; }
}
