public class EnemyDamageViewModel : IEnemyDamageViewModel
{
    public ReactiveProperty<int> Damage { get; private set; } = new ReactiveProperty<int>();

    protected IEnemyDamageModel _model;

    public EnemyDamageViewModel(IEnemyDamageModel model)
    {
        _model = model;

        Damage.Value = model.Config.Damage;
    }
}
