public interface IScoreStrategy
{
    void Initialize(float defaultScore);
    void UpdateScore();
    int GetScore();
}