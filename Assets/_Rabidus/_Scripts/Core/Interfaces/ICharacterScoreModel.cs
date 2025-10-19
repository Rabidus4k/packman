public interface ICharacterScoreModel
{
    public int Score { get; }
    public int MaxScore { get; }
    void AddScore(int score);
    void SetMaxScore(int maxScore);
}
