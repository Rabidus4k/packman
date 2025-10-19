using UnityEngine;

public class CharacterScoreModel : ICharacterScoreModel
{
    public int Score { get; private set; }
    public int MaxScore { get; private set; }
    public void AddScore(int score)
    {
        if (score <= 0)
        {
            Debug.LogError("[AddScore] Wrong score");
            return;
        }

        Score += score;
    }

    public void SetMaxScore(int maxScore)
    {
        MaxScore = maxScore;
    }

    public CharacterScoreModel() { }
}
