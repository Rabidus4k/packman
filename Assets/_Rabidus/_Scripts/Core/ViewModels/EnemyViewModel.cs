using UnityEngine;

public class EnemyViewModel : IEnemyViewModel
{
    public ReactiveProperty<Vector3> TargetPosition { get; protected set; } = new ReactiveProperty<Vector3>();
    public ReactiveProperty<float> VisionDistance { get; protected set; } = new ReactiveProperty<float>();
    public ReactiveProperty<float> RotationSpeed { get; protected set; } = new ReactiveProperty<float>();
    public ReactiveProperty<int> Damage { get; protected set;} = new ReactiveProperty<int>();
    public ReactiveProperty<bool> CanFollow { get; protected set; } = new ReactiveProperty<bool>();

    protected IEnemyModel _model;

    public EnemyViewModel(IEnemyModel model)
    {
        _model = model;

        TargetPosition.Value = model.TargetPosition;
        RotationSpeed.Value = model.Config.RotationSpeed;
        VisionDistance.Value = model.Config.VisionDistance;
        Damage.Value = model.Config.Damage;
        CanFollow.Value = model.CanFollow;
    }

    public void SetTargetPosition(Vector3 position)
    {
        _model.SetTargetPosition(position);
        TargetPosition.Value = _model.TargetPosition;
    }

    public void SetCanFollow(bool canFollow)
    {
        _model.SetCanFollow(canFollow);
        CanFollow.Value = canFollow;
    }
}
