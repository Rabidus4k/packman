using UnityEngine;

public class ScoreViewModel : IScoreViewModel
{
    public ReactiveProperty<int> Score {get; private set;} = new ReactiveProperty<int>();

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
}
