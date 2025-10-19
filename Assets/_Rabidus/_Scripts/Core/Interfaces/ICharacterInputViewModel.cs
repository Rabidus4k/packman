using UnityEngine;

public interface ICharacterInputViewModel
{
    public ReactiveProperty<float> RotationSpeed { get; }
    public ReactiveProperty<Vector3> Movement { get; }
    public ReactiveProperty<Vector3> Position { get; }
    void HandleInput(float horizontal, float vertical);
    void SetPosition(Vector3 position);
}
