using System;
using UnityEngine;

public class ScoreInteractableView : MonoBehaviour
{
    [SerializeField] private CollisionEventsHub _collisionEventsHub;

    private IScoreViewModel _viewModel;

    private void OnEnable()=> _collisionEventsHub.OnTriggerEnterEvent.AddListener(HandleScoreTrigger);
    private void OnDisable() => _collisionEventsHub.OnTriggerEnterEvent.RemoveListener(HandleScoreTrigger);

    private void HandleScoreTrigger(Collider collider)
    {
        if (collider == null) return;
        if (collider.gameObject.TryGetComponent(out Score score))
        {
            var scoreToAdd = score.TryGetScore();
            if (scoreToAdd == 0) return;
            _viewModel.AddScore(scoreToAdd);
        }
    }

    public void Initialize(IScoreViewModel viewModel)
    {
        _viewModel = viewModel;
    }
}
