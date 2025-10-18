using UnityEngine;

public class HealthInteractableView : MonoBehaviour
{
    [SerializeField] private CollisionEventsHub _collisionEventsHub;

    private ICharacterHealthViewModel _viewModel;

    private void OnEnable() => _collisionEventsHub.OnTriggerEnterEvent.AddListener(HandleScoreTrigger);
    private void OnDisable() => _collisionEventsHub.OnTriggerEnterEvent.RemoveListener(HandleScoreTrigger);

    private void HandleScoreTrigger(Collider collider)
    {
        if (collider == null) return;
        if (collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            if (interactable is Heart && interactable.TryInteract())
            {
                _viewModel.GetHeal((interactable as Heart).HealthToAdd);
            }
        }
    }

    public void Initialize(ICharacterHealthViewModel viewModel)
    {
        _viewModel = viewModel;
    }
}
