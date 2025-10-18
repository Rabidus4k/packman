using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent _agent;
    [SerializeField] protected Transform _target;

    protected IEnemyViewModel _viewModel;
    protected float _visionDistance;
    protected bool _canFollow;

    public virtual void Initialize(IEnemyViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.TargetPosition.OnChanged += UpdatePath;
        _viewModel.RotationSpeed.OnChanged += SetRotationSpeed;
        _viewModel.VisionDistance.OnChanged += SetVisionDistance;
        _viewModel.CanFollow.OnChanged += SetCanFollow;

        SetRotationSpeed(_viewModel.RotationSpeed.Value);
        SetVisionDistance(_viewModel.VisionDistance.Value);
    }

    protected virtual void OnDisable()
    {
        _viewModel.TargetPosition.OnChanged -= UpdatePath;
        _viewModel.RotationSpeed.OnChanged -= SetRotationSpeed;
        _viewModel.VisionDistance.OnChanged -= SetVisionDistance;
        _viewModel.CanFollow.OnChanged -= SetCanFollow;
    }

    protected virtual void UpdatePath(Vector3 movement)
    {
        if (_canFollow)
            _agent.SetDestination(movement);
    }

    protected void SetRotationSpeed(float value)
    {
        _agent.angularSpeed = value;
    }

    protected void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, _target.position);

        _viewModel.SetCanFollow(distance <= _visionDistance);
        _viewModel.SetTargetPosition(_target.position);
    }

    protected void SetVisionDistance(float visionDistance)
    {
        _visionDistance = visionDistance;
    }

    protected void SetCanFollow(bool canFollow)
    {
        _canFollow = canFollow;
    }
}
