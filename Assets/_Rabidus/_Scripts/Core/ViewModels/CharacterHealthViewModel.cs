public class CharacterHealthViewModel : ICharacterHealthViewModel
{
    public ReactiveProperty<int> Health { get; private set; } = new ReactiveProperty<int>();
    public ReactiveProperty<bool> IsDead { get; private set; } = new ReactiveProperty<bool>();
    
    protected ICharacterHealthModel _model;

    public CharacterHealthViewModel(ICharacterHealthModel model)
    {
        _model = model;
        Health.Value = model.Health;
    }

    public void GetDamage(int damage)
    {
        _model.GetDamage(damage);
        Health.Value = _model.Health;

        if (Health.Value == 0)
            IsDead.Value = true;
    }

    public void GetHeal(int heal)
    {
        _model.GetHeal(heal);
        Health.Value = _model.Health;
    }
}
