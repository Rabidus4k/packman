using System;
using UnityEngine;
using Zenject;

public class ScoreInteractableView : MonoBehaviour
{
    [SerializeField] private CollisionEventsHub _collisionEventsHub;

    private IScoreViewModel _viewModel;

    private void OnEnable()=> _collisionEventsHub.OnTriggerEnterEvent.AddListener(HandleScoreTrigger);
    private void OnDisable() => _collisionEventsHub.OnTriggerEnterEvent.RemoveListener(HandleScoreTrigger);

    private void HandleScoreTrigger(Collider collider)
    {
        if (collider == null) return;
        if (collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            if (interactable is Score && interactable.TryInteract())
            {
                _viewModel.AddScore((interactable as Score).ScoreToAdd);
            }
        }
    }

    [Inject]
    private void Construct(IScoreViewModel viewModel)
    {
        _viewModel = viewModel;
    }
}
