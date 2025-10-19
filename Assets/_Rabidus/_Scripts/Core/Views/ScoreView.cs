using UnityEngine;
using Zenject;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _scoreText;
    [SerializeField] private int _maxScore;

    private IScoreViewModel _viewModel;

    [Inject]
    private void Construct(IScoreViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Score.OnChanged += HandleScoreChange;
        _viewModel.Score.Value = 0;
    }

    private void Start()
    {
        _viewModel.SetMaxScore(_maxScore);
    }

    private void OnDisable()
    {
        _viewModel.Score.OnChanged -= HandleScoreChange;
    }

    private void HandleScoreChange(int score)
    {
        _scoreText.SetText(score.ToString());
    }
}
