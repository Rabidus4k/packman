using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class UICutsomButton : MonoBehaviour
{
    private Button _button;

    protected virtual void Awake() => _button = GetComponent<Button>();
    protected virtual void OnEnable() => _button.onClick.AddListener(HandleButtonClick);
    protected virtual void OnDisable() => _button.onClick.RemoveListener(HandleButtonClick);
    protected abstract void HandleButtonClick();
}
