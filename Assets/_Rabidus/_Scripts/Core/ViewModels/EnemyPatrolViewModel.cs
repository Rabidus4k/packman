using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolViewModel : EnemyViewModel, IEnemyPatrolViewModel
{
    public ReactiveProperty<List<Transform>> Waypoints { get; protected set; }  = new ReactiveProperty<List<Transform>>();

    private new IEnemyPatrolModel _model;

    public EnemyPatrolViewModel(IEnemyPatrolModel model) : base(model)
    {
        _model = model;
        Waypoints.Value = new List<Transform>();
    }

    public void SetWaypoints(List<Transform> waypoints)
    {
        _model.SetWaypoints(waypoints);
        Waypoints.Value = waypoints;
    }
}
