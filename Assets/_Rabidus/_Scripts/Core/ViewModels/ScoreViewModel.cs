using UnityEngine;

public class ScoreViewModel : CharacterViewModel, IScoreViewModel
{
    public ReactiveProperty<int> Score {get; private set;} = new ReactiveProperty<int>();

    public ScoreViewModel(ICharacterModel model) : base(model)
    {
    }

    public void AddScore(int score)
    {
        _model.AddScore(score);
        Score.Value += score;
    }
}
