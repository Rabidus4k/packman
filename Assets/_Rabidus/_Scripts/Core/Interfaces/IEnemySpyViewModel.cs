using UnityEngine;

public interface IEnemySpyViewModel : IEnemyViewModel
{
    public ReactiveProperty<bool> CanSee { get; }
    public ReactiveProperty<LayerMask> Obstacles { get; }
    public void SetCanSee(bool canSee);
    public void SetObstacles(LayerMask obstacles);
}
