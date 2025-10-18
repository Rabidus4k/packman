using UnityEngine;

public class Heart : MonoBehaviour, IInteractable
{
    [SerializeField] private HealthConfig _config;
    [SerializeField] private InteractableAnimator _animator;

    public int HealthToAdd => _config.HealthToAdd;

    public bool TryInteract()
    {
        if (_config == null) return false;

        _animator.OnCollect();
        SoundManager.Instance.PlaySound("Heal");
        return true;
    }
}
