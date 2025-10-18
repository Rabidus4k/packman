using UnityEngine;

public class CharacterModel : ICharacterModel
{
    public CharacterConfig Config { get; private set; }
    public Vector3 Movement { get; private set;}
    public int Health { get; private set; }
    public int Score { get; private set; }

    public void Initialize(CharacterConfig config) 
    {
        Config = config;
        Health = config.MaxHealth;
    } 

    public void HandleInput(float horizontal, float vertical)
    {
        Movement = new Vector3(horizontal * Config.MoveSpeed, vertical * Config.MoveSpeed);
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

    public void AddScore(int score)
    {
        if (score <= 0)
        {
            Debug.LogError("[GetDamage] Wrong damage");
            return;
        }

        Score += score;
    }
}