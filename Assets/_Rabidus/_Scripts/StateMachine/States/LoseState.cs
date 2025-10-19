using UnityEngine;

public class LoseState : ILoseState
{
    public GameStateId StateID => GameStateId.Lose;
    private IUILoseView _loseView;

    public LoseState(IUILoseView view)
    {
        _loseView = view;
    }

    public void Enter()
    {
        Time.timeScale = 0f;
        _loseView.ShowPanel();
        Debug.Log("[LoseState] Enter");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        _loseView.HidePanel();
        Debug.Log("[LoseState] Exit");

        SceneLoaderInstaller.Instance.ReloadScene();
    }
}

public interface ILoseState : IState
{

}