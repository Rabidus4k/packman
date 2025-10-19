using UnityEngine;

public class WinState : IWinState
{
    public GameStateId StateID => GameStateId.Win;
    private IUIWinView _winView;

    public WinState(IUIWinView view)
    {
        _winView = view;
    }

    public void Enter()
    {
        Time.timeScale = 0f;
        _winView.ShowPanel();
        Debug.Log("[WinState] Enter");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        _winView.HidePanel();
        Debug.Log("[WinState] Exit");

        SceneLoaderInstaller.Instance.ReloadScene();
    }
}

public interface IWinState : IState
{

}