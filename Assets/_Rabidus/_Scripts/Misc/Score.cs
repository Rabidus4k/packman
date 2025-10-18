using Lean.Pool;
using UnityEngine;

public class Score : MonoBehaviour, IInteractable
{
    [SerializeField] private ScoreConfig _config;
    [SerializeField] private InteractableAnimator _animator;

    public int ScoreToAdd => _config.ScoreToAdd;    


    public bool TryInteract()
    {
        if (_config == null) return false;

        _animator.OnCollect();
        SoundManager.Instance.PlaySound("Collect");
        return true;
    }
}
