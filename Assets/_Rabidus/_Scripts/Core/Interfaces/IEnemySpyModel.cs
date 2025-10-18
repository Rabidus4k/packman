public interface IEnemySpyModel : IEnemyModel
{
    public bool CanSee { get; }
    void SetCanSee(bool canSee);
}
