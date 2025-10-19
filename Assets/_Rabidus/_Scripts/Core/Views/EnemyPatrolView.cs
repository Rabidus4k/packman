using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyPatrolView : EnemyView
{
    [SerializeField] private List<Transform> _waypoints = new List<Transform>();
    private new IEnemyPatrolViewModel _viewModel;
    private Transform _currentWaypoint = null;

    [Inject]
    protected void Construct(IEnemyPatrolViewModel viewModel, ICharacterInputViewModel characterViewModel)
    {
        base.Construct(viewModel, characterViewModel);

        _viewModel = viewModel;
        _viewModel.Waypoints.OnChanged += SetWaypoints;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _viewModel.Waypoints.OnChanged -= SetWaypoints;
    }

    private void SetWaypoints(List<Transform> waypoints)
    {
        _waypoints = waypoints;
    }

    protected override void UpdatePath(Vector3 movement)
    {
        if (_canFollow)
            _agent.SetDestination(movement);
        else
            Patrol();
    }

    private void Patrol()
    {
        if (_waypoints == null || _waypoints.Count == 0) return;

        if (_currentWaypoint == null)
        {
            _currentWaypoint = GetRandomWaypoint();
        }

        _agent.SetDestination(_currentWaypoint.position);

        if (Vector3.Distance(transform.position, _currentWaypoint.position) <  _agent.stoppingDistance + 0.1f)
            _currentWaypoint = GetRandomWaypoint();
    }

    private Transform GetRandomWaypoint()
    {
        return _waypoints[Random.Range(0, _waypoints.Count)];
    }
}
