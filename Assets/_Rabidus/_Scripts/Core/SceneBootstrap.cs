using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneBootstrap
{
    private const string ResourcePath = "Bootstrap/Bootstrap";
    private static bool _spawned;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void SpawnOnce()
    {
        if (_spawned) return;
        var prefab = Resources.Load<GameObject>(ResourcePath);
        if (prefab == null) { Debug.LogError($"[GlobalBootstrap] Нет Resources/{ResourcePath}"); return; }

        var inst = Object.Instantiate(prefab);
        Object.DontDestroyOnLoad(inst);
        _spawned = true;
    }
}