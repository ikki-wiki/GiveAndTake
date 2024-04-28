[System.Serializable]
public class PlayerProfile
{
    public string username;
    public int score;

    public PlayerProfile(string username, int score)
    {
        this.username = username;
        this.score = score;
    }
}
