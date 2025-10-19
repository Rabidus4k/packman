using UnityEngine;
using UnityEngine.UI;
using VInspector;
using Zenject;

public class CharacterHealthView : MonoBehaviour
{
    [SerializeField] private UIHealthBar _healthBar;

    private ICharacterHealthViewModel _viewModel;

    [Inject]
    private void Construct(ICharacterHealthViewModel viewModel)
    {
        _viewModel = viewModel;
        _viewModel.Health.OnChanged += HandleHealthChange;

        _healthBar.SetMaxHealth(_viewModel.Health.Value);
    }

    private void OnDisable()
    {
        _viewModel.Health.OnChanged -= HandleHealthChange;
    }

    private void HandleHealthChange(int health)
    {
        _healthBar.SetHealth(health);
        Debug.Log($"[HandleHealthChange] Health: {health}");
    }

    [Button]
    private void DebugSetHelath()
    {
        _healthBar.SetHealth(1);
    }
}
