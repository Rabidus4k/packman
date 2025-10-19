using UnityEngine;

public class StartState : IStartState
{
    public GameStateId StateID => GameStateId.Start;
    private IUIStartView _startView;

    public StartState(IUIStartView startView)
    {
        _startView = startView;
    }

    public void Enter()
    {
        Time.timeScale = 0f;
        _startView.ShowPanel();
        Debug.Log("[StartState] Enter");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        _startView.HidePanel();
        Debug.Log("[StartState] Exit");
    }
}

public interface IStartState : IState
{

}