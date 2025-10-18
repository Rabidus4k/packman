using UnityEngine;

public class EnemySpyView : EnemyView
{
    [SerializeField] private Transform _eyes;
    [SerializeField] private LayerMask _obstacleLayerMask;

    private new IEnemySpyViewModel _viewModel;
    private bool _canSee;

    public void Initialize(IEnemySpyViewModel viewModel)
    {
        base.Initialize(viewModel);

        _viewModel = viewModel;
        _viewModel.CanSee.OnChanged += SetCanSee;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _viewModel.CanSee.OnChanged -= SetCanSee;
    }

    private void SetCanSee(bool canSee)
    {
        _canSee = canSee;
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
        float distanceToPlayer = Vector3.Distance(transform.position, _target.position);
        float rayDistance = Mathf.Min(distanceToPlayer, _visionDistance);

        var direction = _target.position - transform.position;

        Debug.DrawRay(_eyes.position, direction.normalized * rayDistance, Color.red);
        return Physics.Raycast(_eyes.position, direction.normalized, rayDistance, _obstacleLayerMask);
    }
}
