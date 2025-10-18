using Lean.Pool;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreConfig _config;
    [SerializeField] private CoinAnimator _coinAnimator;

    public int TryGetScore()
    {
        if (_config == null) return 0;

        _coinAnimator.OnCollect();
        return _config.ScoreToAdd;
    }
}
