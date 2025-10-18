using System.Collections.Generic;
using UnityEngine;

public interface IEnemyPatrolViewModel : IEnemyViewModel
{
    public ReactiveProperty<List<Transform>> Waypoints { get; }
    public void SetWaypoints(List<Transform> waypoints);
}
