using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolModel : EnemyModel, IEnemyPatrolModel
{
    public List<Transform> Waypoints { get; private set; } = new List<Transform>();
    
    public EnemyPatrolModel(IEnemyConfig config) : base(config)
    {
    }

    public void SetWaypoints(List<Transform> waypoints)
    {
        Waypoints = waypoints;
    }
}
