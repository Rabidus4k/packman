using UnityEngine;

public class PauseState : IPauseState
{
    public GameStateId StateID => GameStateId.Pause;
    private IUIPauseView _pauseView;

    public PauseState(IUIPauseView view)
    {
        _pauseView = view;
    }

    public void Enter()
    {
        Time.timeScale = 0f;
        _pauseView.ShowPanel();
        Debug.Log("[PauseState] Enter");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        _pauseView.HidePanel();
        Debug.Log("[PauseState] Exit");
    }
}

public interface IPauseState: IState
{

}