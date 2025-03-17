Here's a short specification for a simple MVP Leaderboard API in C# that stores data in memory:

Leaderboard API Specification
Version: 1.0

Overview:
This is a minimal RESTful API for managing a game leaderboard, using in-memory storage. It will support basic CRUD operations for player scores.

Base URL: /api/leaderboard

Endpoints:

All endpoints should be in program.cs and follow this code pattern.

```csharp
app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");
```

1. GET /scores
- Description: Retrieves the full leaderboard sorted by score (descending)
- Response: 200 OK
- Response Body: 
```json
[
    {
        "playerId": "string",
        "playerName": "string",
        "score": integer,
        "timestamp": "datetime"
    }
]
```

2. POST /scores
- Description: Adds or updates a player's score
- Request Body:
```json
{
    "playerId": "string",
    "playerName": "string",
    "score": integer
}
```
- Responses:
  - 201 Created (new entry)
  - 200 OK (updated existing entry)
  - 400 Bad Request (invalid data)

3. GET /scores/{playerId}
- Description: Gets a specific player's score
- Parameters: playerId (string)
- Response: 200 OK
- Response Body:
```json
{
    "playerId": "string",
    "playerName": "string",
    "score": integer,
    "timestamp": "datetime"
}
```
- Error: 404 Not Found

Data Model:
```csharp
public class ScoreEntry 
{
    public string PlayerId { get; set; }
    public string PlayerName { get; set; }
    public int Score { get; set; }
    public DateTime Timestamp { get; set; }
}
```

Storage:
- In-memory List<ScoreEntry>
- Thread-safe access using lock or ConcurrentDictionary

Technical Details:
- Framework: ASP.NET Core Web API
- Language: C# 
- Storage: In-memory collection (data lost on restart)
- No authentication (MVP version)
- Basic input validation
- JSON serialization
- Data models are stored in folder /data
- Logic and services are stored in folder /lib
- For each new endpoint, a http rest file should be created that makes a request to the new endpoint
  - URL for api is http://localhost:5056
  - Files should be created in the /Requests folder

Notes:
- Scores are stored with timestamps of creation/update
- Leaderboard is sorted by score (highest first)
- PlayerId must be unique
- This is an MVP - future versions could add persistence, authentication, and more features

Would you like me to provide sample C# code to implement this specification?