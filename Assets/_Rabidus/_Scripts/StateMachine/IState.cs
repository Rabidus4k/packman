public interface IState
{
    public GameStateId StateID { get; }
    void Enter();
    void Exit();
}