using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UICutsomButton : MonoBehaviour, IUICutsomButton
{
    private Button _button;

    protected virtual void Awake() => _button = GetComponent<Button>();
    protected virtual void OnEnable() => _button.onClick.AddListener(HandleButtonClick);
    protected virtual void OnDisable() => _button.onClick.RemoveListener(HandleButtonClick);

    public virtual void HandleButtonClick()
    {
        
    }
}

public interface IUICutsomButton
{
    void HandleButtonClick();
}
