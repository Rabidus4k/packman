using UnityEngine;

public class EnemyDamageView : MonoBehaviour, IInteractable
{
    private IEnemyDamageViewModel _viewModel;
    private int _damage;
    public int Damage => _damage;

    public void Initialize(IEnemyDamageViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Damage.OnChanged += SetDamage;

        SetDamage(_viewModel.Damage.Value);
    }

    private void SetDamage(int damage)
    {
        _damage = damage;
    }

    private void OnDisable()
    {
        _viewModel.Damage.OnChanged -= SetDamage;
    }

    public bool TryInteract()
    {
        return true;
    }
}
