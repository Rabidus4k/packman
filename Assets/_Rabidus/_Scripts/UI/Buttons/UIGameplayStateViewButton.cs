using Zenject;

public class UIGameplayStateViewButton : UIStateViewButton
{
    [Inject]
    protected void Construct(IStateMachine stateMachine, IGameplayState state)
    {
        _state = state;
        _stateMachine = stateMachine;
    }
}
