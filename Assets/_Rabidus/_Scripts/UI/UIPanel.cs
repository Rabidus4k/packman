using UnityEngine;
using VInspector;

[RequireComponent(typeof(CanvasGroup))]
public class UIPanel : MonoBehaviour
{
    [SerializeField] protected CanvasGroup _cg;

    protected virtual void Awake() => _cg = GetComponent<CanvasGroup>();

    [Button]
    public virtual void ShowPanel()
    {
        _cg.alpha = 1;
        _cg.blocksRaycasts = true;
    }

    [Button]
    public virtual void HidePanel()
    {
        _cg.alpha = 0;
        _cg.blocksRaycasts = false;
    }
}
