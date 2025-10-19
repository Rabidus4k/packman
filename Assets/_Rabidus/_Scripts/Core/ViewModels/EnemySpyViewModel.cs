using UnityEngine;

public class EnemySpyViewModel : EnemyViewModel, IEnemySpyViewModel
{
    public ReactiveProperty<bool> CanSee { get; private set; } = new ReactiveProperty<bool> ();
    public ReactiveProperty<LayerMask> Obstacles { get; private set; } = new ReactiveProperty<LayerMask>();

    private new IEnemySpyModel _model;

    public EnemySpyViewModel(IEnemySpyModel model) : base(model)
    {
        _model = model;

        CanSee.Value = model.CanSee;
        Obstacles.Value = 1;
    }

    public void SetCanSee(bool canSee)
    {
        _model.SetCanSee(canSee);
        CanSee.Value = canSee;
    }

    public void SetObstacles(LayerMask obstacles)
    {
        _model.SetObstacles(obstacles);
        Obstacles.Value = obstacles;
    }
}
