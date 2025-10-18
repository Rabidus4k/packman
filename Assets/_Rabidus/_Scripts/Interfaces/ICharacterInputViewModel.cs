using UnityEngine;

public interface ICharacterInputViewModel
{
    public ReactiveProperty<float> RotationSpeed { get; }
    public ReactiveProperty<Vector3> Movement { get; }
    void HandleInput(float horizontal, float vertical);
}
