using System;
using System.Collections.Generic;
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
    [SerializeField] private CharacterConfig _characterConfig;

    [Header("Enemy")]
    [SerializeField] private EnemyView _enemyView;
    [SerializeField] private EnemyDamageView _enemyDamageView;
    [SerializeField] private EnemyConfig _enemyConfig;

    [Header("Patrol Enemy")]
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private EnemyPatrolView _enemyPatrolView;
    [SerializeField] private EnemyDamageView _enemyPatrolDamageView;
    [SerializeField] private EnemyConfig _enemyPatrolConfig;

    [Header("Spy Enemy")]
    [SerializeField] private EnemySpyView _enemySpyView;
    [SerializeField] private EnemyDamageView _enemySpyDamageView;
    [SerializeField] private EnemyConfig _enemySpyConfig;

    private void Awake()
    {
        SetupPlayer();
        SetupEnemy();
        SetupPatrolEnemy();
        SetupSpyEnemy();
    }

    private void SetupSpyEnemy()
    {
        EnemySpyModel enemyModel = new EnemySpyModel();
        EnemyDamageModel enemyDamageModel = new EnemyDamageModel();

        enemyModel.Initialize(_enemySpyConfig);
        enemyDamageModel.Initialize(_enemySpyConfig);

        EnemySpyViewModel enemyViewModel = new EnemySpyViewModel(enemyModel);
        EnemyDamageViewModel enemyDamageViewModel = new EnemyDamageViewModel(enemyDamageModel);

        _enemySpyView.Initialize(enemyViewModel);
        _enemySpyDamageView.Initialize(enemyDamageViewModel);
    }

    private void SetupPatrolEnemy()
    {
        EnemyPatrolModel enemyModel = new EnemyPatrolModel();
        EnemyDamageModel enemyDamageModel = new EnemyDamageModel();

        enemyModel.Initialize(_enemyPatrolConfig);
        enemyDamageModel.Initialize(_enemyPatrolConfig);

        EnemyPatrolViewModel enemyViewModel = new EnemyPatrolViewModel(enemyModel);

        EnemyDamageViewModel enemyDamageViewModel = new EnemyDamageViewModel(enemyDamageModel);

        _enemyPatrolView.Initialize(enemyViewModel);
        _enemyPatrolDamageView.Initialize(enemyDamageViewModel);
    }

    private void SetupEnemy()
    {
        EnemyModel enemyModel = new EnemyModel();
        EnemyDamageModel enemyDamageModel = new EnemyDamageModel();

        enemyModel.Initialize(_enemyConfig);
        enemyDamageModel.Initialize(_enemyConfig);

        EnemyViewModel enemyViewModel = new EnemyViewModel(enemyModel);
        EnemyDamageViewModel enemyDamageViewModel = new EnemyDamageViewModel(enemyDamageModel);

        _enemyView.Initialize(enemyViewModel);
        _enemyDamageView.Initialize(enemyDamageViewModel);
    }

    private void SetupPlayer()
    {
        CharacterInputModel characterModel = new CharacterInputModel();
        CharacterHealthModel characterHealthModel = new CharacterHealthModel();
        CharacterScoreModel characterScoreModel = new CharacterScoreModel();

        characterModel.Initialize(_characterConfig);
        characterHealthModel.Initialize(_characterConfig);

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
