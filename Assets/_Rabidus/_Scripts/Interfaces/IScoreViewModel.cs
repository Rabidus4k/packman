public interface IScoreViewModel
{
    public ReactiveProperty<int> Score { get; }
    void AddScore(int score);
}
