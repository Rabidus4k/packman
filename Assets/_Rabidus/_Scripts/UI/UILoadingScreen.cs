using UnityEngine;
using UnityEngine.UI;

public class UILoadingScreen : UIPanel, ILoadingScreen
{
    [SerializeField] private Slider _bar;

    public void SetProgress(float value) => _bar.value = value;

    public void Show()
    {
        ShowPanel();
    }

    public void Hide()
    {
        HidePanel();
    }
}