public interface IScoreViewModel
{
    public ReactiveProperty<int> Score { get; }
    public ReactiveProperty<int> MaxScore { get; }
    void AddScore(int score);
    void SetMaxScore(int maxScore);
}
