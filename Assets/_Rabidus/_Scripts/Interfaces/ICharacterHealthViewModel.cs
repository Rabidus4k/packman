public interface ICharacterHealthViewModel
{
    public ReactiveProperty<int> Health { get; }
    public ReactiveProperty<bool> IsDead { get; }
    void GetDamage(int damage);
    void GetHeal(int heal);
}
