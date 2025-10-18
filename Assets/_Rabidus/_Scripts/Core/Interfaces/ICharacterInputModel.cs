using UnityEngine;

public interface ICharacterInputModel
{
    //Configs
    public CharacterConfig Config { get; }

    //Movement
    public Vector3 Movement { get; }

    void HandleInput(float horizontal, float vertical);
}
