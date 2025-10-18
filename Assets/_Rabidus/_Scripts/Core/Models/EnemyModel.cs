using System.Collections.Generic;
using UnityEngine;

public class EnemyModel : IEnemyModel
{
    public EnemyConfig Config {get; private set;}

    public Vector3 TargetPosition {get; private set;}

    public bool CanFollow {get; private set;}

    public void Initialize(EnemyConfig config)
    {
        Config = config;
    }

    public void SetCanFollow(bool canFollow)
    {
        CanFollow = canFollow;
    }

    public void SetTargetPosition(Vector3 position)
    {
        TargetPosition = position;
    }
}
