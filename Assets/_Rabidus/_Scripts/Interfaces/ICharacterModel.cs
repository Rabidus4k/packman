using UnityEngine;

public interface ICharacterModel
{
    //Configs
    public CharacterConfig Config { get; }

    //Movement
    public Vector3 Movement { get; }

    //Health
    public int Health { get; }

    //Score
    public int Score { get; }

    void HandleInput(float horizontal, float vertical);
    void GetDamage(int damage);
    void GetHeal(int heal);
    void AddScore(int score);
}
