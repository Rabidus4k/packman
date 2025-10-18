public interface ICharacterHealthModel
{
    //Configs
    public CharacterConfig Config { get; }

    //Health
    public int Health { get; }

    void GetDamage(int damage);
    void GetHeal(int heal);
}
