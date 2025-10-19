using UnityEngine;

public class UISceneLoaderButton : UICutsomButton
{
    [SerializeField] private string _sceneName;

    public override void HandleButtonClick()
    {
        SceneLoaderInstaller.Instance.LoadScene(_sceneName);
    }
}
