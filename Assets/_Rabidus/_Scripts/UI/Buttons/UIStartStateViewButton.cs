using Zenject;

public class UIStartStateViewButton : UIStateViewButton
{
    [Inject]
    protected void Construct(IStateMachine stateMachine, IStartState state)
    {
        _state = state;
        _stateMachine = stateMachine;
    }
}
