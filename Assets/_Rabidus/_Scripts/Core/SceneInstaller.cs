using System;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class SceneInstaller : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private CharacterHealthView _healthView;
    [SerializeField] private CharacterInputView _inputView;
    [SerializeField] private ScoreView _scoreView;
    [SerializeField] private ScoreInteractableView _scoreInteractableView;
    [SerializeField] private HealthInteractableView _healthInteractableView;

    [SerializeField] private CharacterConfig _config;
    private void Awake()
    {
        SetupPlayer();
    }

    private void SetupPlayer()
    {
        CharacterModel characterModel = new CharacterModel();
        CharacterHealthModel characterHealthModel = new CharacterHealthModel();
        CharacterScoreModel characterScoreModel = new CharacterScoreModel();

        characterModel.Initialize(_config);
        characterHealthModel.Initialize(_config);

        CharacterHealthViewModel characterHealthViewModel = new CharacterHealthViewModel(characterHealthModel);
        CharacterInputViewModel characterInputViewModel = new CharacterInputViewModel(characterModel);
        ScoreViewModel scoreViewModel = new ScoreViewModel(characterScoreModel);
        
        _healthView.Initialize(characterHealthViewModel);
        _healthInteractableView.Initialize(characterHealthViewModel);

        _inputView.Initialize(characterInputViewModel);

        _scoreView.Initialize(scoreViewModel);
        _scoreInteractableView.Initialize(scoreViewModel);
    }
}
