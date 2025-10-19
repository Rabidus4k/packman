using UnityEngine;

public interface ICharacterInputModel
{
    public ICharacterConfig Config { get; }
    public Vector3 Movement { get; }
    public Vector3 Position { get; }
    void HandleInput(float horizontal, float vertical);
    void SetPosition(Vector3 position);
}
