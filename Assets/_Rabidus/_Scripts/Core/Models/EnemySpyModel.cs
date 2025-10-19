using UnityEngine;

public class EnemySpyModel : EnemyModel, IEnemySpyModel
{
    public bool CanSee {get; private set;}
    public LayerMask ObstacleLayerMask { get; private set;}

    public EnemySpyModel(IEnemyConfig config) : base(config)
    {
    }

    public void SetObstacles(LayerMask layerMask)
    {
        ObstacleLayerMask = layerMask;
    }

    public void SetCanSee(bool canSee)
    {
        CanSee = canSee;
    }
}
