namespace Leaderboard.Data;

public class ScoreEntry 
{
    public string PlayerId { get; set; } = string.Empty;
    public string PlayerName { get; set; } = string.Empty;
    public int Score { get; set; }
    public DateTime Timestamp { get; set; }
}
