using UnityEngine;

public class GameStateMachine : IStateMachine
{
    private IState _currentState;

    public GameStateMachine(IStartState startState)
    {
        ChangeState(startState);
    }

    public void ChangeState(IState state)
    {
        if (_currentState != null && state == _currentState) return;

        _currentState?.Exit();
        _currentState = state;
        _currentState.Enter();

#if UNITY_EDITOR
        Debug.Log($"[StateMachine] -> {state}");
#endif
    }
}
