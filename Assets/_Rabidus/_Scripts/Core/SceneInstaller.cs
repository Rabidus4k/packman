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
        CharacterModel playerModel = new CharacterModel();
        playerModel.Initialize(_config);

        CharacterHealthViewModel characterHealthViewModel = new CharacterHealthViewModel(playerModel);
        CharacterInputViewModel characterInputViewModel = new CharacterInputViewModel(playerModel);
        ScoreViewModel scoreViewModel = new ScoreViewModel(playerModel);
        
        _healthView.Initialize(characterHealthViewModel);
        _healthInteractableView.Initialize(characterHealthViewModel);

        _inputView.Initialize(characterInputViewModel);

        _scoreView.Initialize(scoreViewModel);
        _scoreInteractableView.Initialize(scoreViewModel);
    }
}
