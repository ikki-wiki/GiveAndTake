public class TimerBasedScoreStrategy : IScoreStrategy
{
    private int score;

    public void Initialize(float defaultScore)
    {
        score = (int)defaultScore;
    }

    public void UpdateScore()
    {
        // Implement the logic to update the score based on the timer
        // For example, decrease the score every second
    }

    public int GetScore()
    {
        return score;
    }
}