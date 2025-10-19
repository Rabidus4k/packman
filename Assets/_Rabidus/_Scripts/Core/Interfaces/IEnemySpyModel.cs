using UnityEngine;

public interface IEnemySpyModel : IEnemyModel
{
    public bool CanSee { get; }
    public LayerMask ObstacleLayerMask { get; }
    void SetCanSee(bool canSee);
    void SetObstacles(LayerMask layerMask);
}
