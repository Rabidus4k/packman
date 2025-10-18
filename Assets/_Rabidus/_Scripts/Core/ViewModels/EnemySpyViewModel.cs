public class EnemySpyViewModel : EnemyViewModel, IEnemySpyViewModel
{
    public ReactiveProperty<bool> CanSee { get; private set; } = new ReactiveProperty<bool> ();

    private new IEnemySpyModel _model;

    public EnemySpyViewModel(IEnemySpyModel model) : base(model)
    {
        _model = model;

        CanSee.Value = model.CanSee;
    }

    public void SetCanSee(bool canSee)
    {
        _model.SetCanSee(canSee);
        CanSee.Value = canSee;
    }
}
