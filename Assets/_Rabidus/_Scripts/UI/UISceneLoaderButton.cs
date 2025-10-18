using UnityEngine;

public class UISceneLoaderButton : UICutsomButton
{
    [SerializeField] private string _sceneName;

    protected override void HandleButtonClick()
    {
        SceneLoaderInstaller.Instance.LoadScene(_sceneName);
    }
}
