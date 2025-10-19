public class UIStateViewButton : UICutsomButton
{
    protected IStateMachine _stateMachine;
    protected IState _state;

    public override void HandleButtonClick()
    {
        _stateMachine.ChangeState(_state);
    }
}
