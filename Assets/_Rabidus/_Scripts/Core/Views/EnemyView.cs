using System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class EnemyView : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent _agent;

    protected IEnemyViewModel _viewModel;
    protected ICharacterInputViewModel _characterInputViewModel;

    protected float _visionDistance;
    protected bool _canFollow;

    [Inject]
    protected void Construct(IEnemyViewModel viewModel, ICharacterInputViewModel characterViewModel)
    {
        _viewModel = viewModel;

        _viewModel.RotationSpeed.OnChanged += SetRotationSpeed;
        _viewModel.VisionDistance.OnChanged += SetVisionDistance;
        _viewModel.CanFollow.OnChanged += SetCanFollow;

        _characterInputViewModel = characterViewModel;
        _characterInputViewModel.Position.OnChanged += UpdatePath;

        SetRotationSpeed(_viewModel.RotationSpeed.Value);
        SetVisionDistance(_viewModel.VisionDistance.Value);
    }

    protected virtual void OnDisable()
    {
        _viewModel.RotationSpeed.OnChanged -= SetRotationSpeed;
        _viewModel.VisionDistance.OnChanged -= SetVisionDistance;
        _viewModel.CanFollow.OnChanged -= SetCanFollow;
        _characterInputViewModel.Position.OnChanged -= UpdatePath;
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

    protected virtual void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, _characterInputViewModel.Position.Value);

        _viewModel.SetCanFollow(distance <= _visionDistance);
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
