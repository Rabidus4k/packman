using UnityEngine;

public class EnemyModel : IEnemyModel
{
    public IEnemyConfig Config {get; private set;}

    public Vector3 TargetPosition {get; private set;}

    public bool CanFollow {get; private set;}

    public EnemyModel(IEnemyConfig config)
    {
        Config = config;
    }

    public void SetCanFollow(bool canFollow)
    {
        CanFollow = canFollow;
    }
}
