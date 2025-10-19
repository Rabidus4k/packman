using UnityEngine;
using Zenject;

public class StateMachineInstaller : MonoInstaller
{
    [SerializeField] private UIStartView _startPanel;
    [SerializeField] private UIPauseView _pausePanel;
    [SerializeField] private UIWinView _winPanel;
    [SerializeField] private UILoseView _losePanel;

    public override void InstallBindings()
    {
        Container.Bind<IStateMachine>().To<GameStateMachine>().AsSingle();

        Container.Bind<IUIStartView>().FromInstance(_startPanel).AsSingle();
        Container.Bind<IUIPauseView>().FromInstance(_pausePanel).AsSingle();
        Container.Bind<IUIWinView>().FromInstance(_winPanel).AsSingle();
        Container.Bind<IUILoseView>().FromInstance(_losePanel).AsSingle();

        Container.Bind<IStartState>().To<StartState>().AsSingle();
        Container.Bind<IPauseState>().To<PauseState>().AsSingle();
        Container.Bind<IGameplayState>().To<GameplayState>().AsSingle();
        Container.Bind<ILoseState>().To<LoseState>().AsSingle();
        Container.Bind<IWinState>().To<WinState>().AsSingle();
    }
}
