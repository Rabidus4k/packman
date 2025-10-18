using UnityEngine;

public class ApplicationSettings : Singleton<ApplicationSettings>
{
    [SerializeField] private int _targetFramerate;

    protected override void Awake()
    {
        base.Awake();
        Application.targetFrameRate = _targetFramerate;
    }
}
