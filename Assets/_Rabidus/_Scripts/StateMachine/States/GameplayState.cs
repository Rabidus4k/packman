using System;
using UnityEngine;

public class GameplayState : IGameplayState
{
    public GameStateId StateID => GameStateId.Game;

    private ICharacterHealthViewModel _characterHealthViewModel;
    private IScoreViewModel _scoreViewModel;
    private IStateMachine _stateMachine;
    private ILoseState _loseState;
    private IWinState _winState;

    public GameplayState
    (
        ICharacterHealthViewModel characterHealthViewModel,
        IScoreViewModel scoreViewModel, 
        IStateMachine stateMachine,
        ILoseState loseState,
        IWinState winState
    )
    {
        _characterHealthViewModel = characterHealthViewModel;
        _scoreViewModel = scoreViewModel;
        _stateMachine = stateMachine;
        _loseState = loseState;
        _winState = winState;
    }

    public void Enter()
    {
        Debug.Log("[GameplayState] Enter");
        _characterHealthViewModel.Health.OnChanged += HandleHealthChange;
        _scoreViewModel.Score.OnChanged += HandleScoreChange;
    }

    public void Exit()
    {
        Debug.Log("[GameplayState] Exit");
        _characterHealthViewModel.Health.OnChanged -= HandleHealthChange;
        _scoreViewModel.Score.OnChanged -= HandleScoreChange;
    }

    private void HandleHealthChange(int health)
    {
        if (health == 0)
            _stateMachine.ChangeState(_loseState);
    }

    private void HandleScoreChange(int score)
    {
        if (score == _scoreViewModel.MaxScore.Value)
            _stateMachine.ChangeState(_winState);
    }
}

public interface IGameplayState : IState
{

}