using UnityEngine;

public interface IEnemyViewModel
{
    public ReactiveProperty<float> RotationSpeed { get; }
    public ReactiveProperty<float> VisionDistance { get; }
    public ReactiveProperty<Vector3> TargetPosition { get; }
    public ReactiveProperty<bool> CanFollow { get; }
    void SetTargetPosition(Vector3 position);
    void SetCanFollow(bool canFollow);
}
