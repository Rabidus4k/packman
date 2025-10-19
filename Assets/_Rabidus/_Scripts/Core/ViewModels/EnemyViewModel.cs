using UnityEngine;

public class EnemyViewModel : IEnemyViewModel
{
    public ReactiveProperty<float> VisionDistance { get; protected set; } = new ReactiveProperty<float>();
    public ReactiveProperty<float> RotationSpeed { get; protected set; } = new ReactiveProperty<float>();
    public ReactiveProperty<int> Damage { get; protected set;} = new ReactiveProperty<int>();
    public ReactiveProperty<bool> CanFollow { get; protected set; } = new ReactiveProperty<bool>();

    protected IEnemyModel _model;

    public EnemyViewModel(IEnemyModel model)
    {
        _model = model;

        RotationSpeed.Value = model.Config.RotationSpeed;
        VisionDistance.Value = model.Config.VisionDistance;
        Damage.Value = model.Config.Damage;
        CanFollow.Value = model.CanFollow;
    }

    public void SetCanFollow(bool canFollow)
    {
        _model.SetCanFollow(canFollow);
        CanFollow.Value = canFollow;
    }
}
