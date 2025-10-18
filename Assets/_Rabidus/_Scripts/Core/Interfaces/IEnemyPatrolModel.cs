using System.Collections.Generic;
using UnityEngine;

public interface IEnemyPatrolModel : IEnemyModel
{
    public List<Transform> Waypoints { get; }
    void SetWaypoints(List<Transform> waypoints);
}
