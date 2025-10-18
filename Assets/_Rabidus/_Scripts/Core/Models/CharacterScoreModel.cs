using UnityEngine;

public class CharacterScoreModel : ICharacterScoreModel
{
    public int Score { get; private set; }

    public void AddScore(int score)
    {
        if (score <= 0)
        {
            Debug.LogError("[GetDamage] Wrong damage");
            return;
        }

        Score += score;
    }
}
