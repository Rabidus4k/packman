using UnityEngine;

public class CharacterInputModel : ICharacterInputModel
{
    public ICharacterConfig Config { get; private set; }
    public Vector3 Movement { get; private set;}
    public Vector3 Position { get; private set;}

    public CharacterInputModel(ICharacterConfig config) 
    {
        Config = config;
    } 

    public void HandleInput(float horizontal, float vertical)
    {
        Movement = new Vector3(horizontal * Config.MoveSpeed, vertical * Config.MoveSpeed);
    }

    public void SetPosition(Vector3 position)
    {
        Position = position;
    }
}