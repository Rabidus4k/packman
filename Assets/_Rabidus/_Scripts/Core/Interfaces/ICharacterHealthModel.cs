public interface ICharacterHealthModel
{
    //Configs
    public ICharacterConfig Config { get; }

    //Health
    public int Health { get; }

    void GetDamage(int damage);
    void GetHeal(int heal);
}
