using Zenject;

public class UIPauseStateViewButton : UIStateViewButton
{
    public string Debug;

    [Inject]
    protected void Construct(IStateMachine stateMachine, IPauseState state)
    {
        Debug = state.StateID.ToString();
        _state = state;
        _stateMachine = stateMachine;
    }
}
