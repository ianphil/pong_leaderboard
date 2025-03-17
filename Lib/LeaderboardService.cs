using Leaderboard.Data;
using System.Collections.Concurrent;

namespace Leaderboard.Lib;

public class LeaderboardService
{
    private readonly ConcurrentDictionary<string, ScoreEntry> _scores = new();
    
    public IEnumerable<ScoreEntry> GetAllScores()
    {
        return _scores.Values.OrderByDescending(s => s.Score).ToList();
    }
    
    public ScoreEntry? GetPlayerScore(string playerId)
    {
        return _scores.TryGetValue(playerId, out var score) ? score : null;
    }
    
    public (bool isNewEntry, ScoreEntry entry) AddOrUpdateScore(ScoreEntry newScore)
    {
        bool isNewEntry = !_scores.ContainsKey(newScore.PlayerId);
        newScore.Timestamp = DateTime.UtcNow;
        
        _scores[newScore.PlayerId] = newScore;
        return (isNewEntry, newScore);
    }
}
