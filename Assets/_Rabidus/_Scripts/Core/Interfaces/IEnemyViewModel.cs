using UnityEngine;

public interface IEnemyViewModel
{
    public ReactiveProperty<float> RotationSpeed { get; }
    public ReactiveProperty<float> VisionDistance { get; }
    public ReactiveProperty<bool> CanFollow { get; }
    void SetCanFollow(bool canFollow);
}
