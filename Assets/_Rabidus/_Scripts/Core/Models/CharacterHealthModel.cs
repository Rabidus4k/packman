using UnityEngine;

public class CharacterHealthModel : ICharacterHealthModel
{
    public CharacterConfig Config { get; private set; }
    public int Health { get; private set; }

    public void Initialize(CharacterConfig config)
    {
        Config = config;
        Health = config.MaxHealth;
    }

    public void GetDamage(int damage)
    {
        if (damage <= 0)
        {
            Debug.LogError("[GetDamage] Wrong damage");
            return;
        }

        Health = Mathf.Clamp(Health - damage, 0, Config.MaxHealth);
    }

    public void GetHeal(int heal)
    {
        if (heal <= 0)
        {
            Debug.LogError("[GetHeal] Wrong damage");
            return;
        }

        Health = Mathf.Clamp(Health + heal, 0, Config.MaxHealth);
    }
}
