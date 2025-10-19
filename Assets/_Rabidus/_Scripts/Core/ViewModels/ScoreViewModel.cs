public class ScoreViewModel : IScoreViewModel
{
    public ReactiveProperty<int> Score { get; private set; } = new ReactiveProperty<int>();
    public ReactiveProperty<int> MaxScore { get; private set; } = new ReactiveProperty<int>();

    protected ICharacterScoreModel _model;

    public ScoreViewModel(ICharacterScoreModel model)
    {
        _model = model;
    }

    public void AddScore(int score)
    {
        _model.AddScore(score);
        Score.Value += score;
    }

    public void SetMaxScore(int maxScore)
    {
        _model.SetMaxScore(maxScore);
        MaxScore.Value = maxScore;
    }
}
