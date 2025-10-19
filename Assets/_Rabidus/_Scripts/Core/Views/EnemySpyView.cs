using System;
using UnityEngine;
using Zenject;

public class EnemySpyView : EnemyView
{
    [SerializeField] private Transform _eyes;

    private new IEnemySpyViewModel _viewModel;
    private bool _canSee;
    private LayerMask _obstacles;

    [Inject]
    protected void Construct(IEnemySpyViewModel viewModel, ICharacterInputViewModel characterViewModel)
    {
        base.Construct(viewModel, characterViewModel);

        _viewModel = viewModel;
        _viewModel.CanSee.OnChanged += SetCanSee;
        _viewModel.Obstacles.OnChanged += SetObstacles;

        SetObstacles(_viewModel.Obstacles.Value);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _viewModel.CanSee.OnChanged -= SetCanSee;
        _viewModel.Obstacles.OnChanged -= SetObstacles;
    }

    private void SetCanSee(bool canSee)
    {
        _canSee = canSee;
    }

    private void SetObstacles(LayerMask mask)
    {
        _obstacles = mask;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        _viewModel.SetCanSee(!CheckForWall());
    }

    protected override void UpdatePath(Vector3 movement)
    {
        if (_canFollow && _canSee)
            _agent.SetDestination(movement);
    }

    private bool CheckForWall()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _characterInputViewModel.Position.Value);
        float rayDistance = Mathf.Min(distanceToPlayer, _visionDistance);

        var direction = _characterInputViewModel.Position.Value - transform.position;

        Debug.DrawRay(_eyes.position, direction.normalized * rayDistance, Color.red);
        return Physics.Raycast(_eyes.position, direction.normalized, rayDistance, _obstacles);
    }
}
