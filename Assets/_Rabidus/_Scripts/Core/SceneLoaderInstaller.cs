using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VInspector;

public class SceneLoaderInstaller : Singleton<SceneLoaderInstaller>
{
    [SerializeField] private UILoadingScreen _loadingsScreen;

    protected override void Awake()
    {
        base.Awake();
        SceneLoader.LoadingScreen = _loadingsScreen;
    }

    public void LoadScene(string scene)
    {
        SceneLoader.SwitchAsync(scene).Forget();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
