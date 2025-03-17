using Leaderboard.Data;
using Leaderboard.Lib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<LeaderboardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Add static files middleware
app.UseStaticFiles();

// API Endpoints go here
app.MapGet("/api/leaderboard/scores", (LeaderboardService leaderboardService) =>
{
    return Results.Ok(leaderboardService.GetAllScores());
})
.WithName("GetAllScores")
.WithOpenApi();

app.MapGet("/api/leaderboard/scores/{playerId}", (string playerId, LeaderboardService leaderboardService) =>
{
    var score = leaderboardService.GetPlayerScore(playerId);
    if (score == null)
    {
        return Results.NotFound();
    }
    
    return Results.Ok(score);
})
.WithName("GetPlayerScore")
.WithOpenApi();

app.MapPost("/api/leaderboard/scores", (ScoreEntry scoreEntry, LeaderboardService leaderboardService) =>
{
    if (string.IsNullOrEmpty(scoreEntry.PlayerId) || string.IsNullOrEmpty(scoreEntry.PlayerName))
    {
        return Results.BadRequest("PlayerId and PlayerName are required");
    }
    
    var (isNewEntry, entry) = leaderboardService.AddOrUpdateScore(scoreEntry);
    
    return isNewEntry ? Results.Created($"/api/leaderboard/scores/{entry.PlayerId}", entry) : Results.Ok(entry);
})
.WithName("AddOrUpdateScore")
.WithOpenApi();

// Endpoint to serve the pong game
app.MapGet("/game/pong", (IWebHostEnvironment env) => 
{
    string filePath = Path.Combine(env.WebRootPath, "pong.html");
    return Results.File(filePath, "text/html");
})
.WithName("GetPongGame")
.WithOpenApi();

app.Run();
