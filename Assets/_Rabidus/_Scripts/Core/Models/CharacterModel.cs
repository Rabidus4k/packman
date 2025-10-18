using UnityEngine;

public class CharacterModel : ICharacterModel
{
    public CharacterConfig Config { get; private set; }
    public Vector3 Movement { get; private set;}

    public void Initialize(CharacterConfig config) 
    {
        Config = config;
    } 

    public void HandleInput(float horizontal, float vertical)
    {
        Movement = new Vector3(horizontal * Config.MoveSpeed, vertical * Config.MoveSpeed);
    }
}