public interface IEnemySpyViewModel : IEnemyViewModel
{
    public ReactiveProperty<bool> CanSee { get; }
    public void SetCanSee(bool canSee);
}
