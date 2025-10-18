using System;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static ILoadingScreen LoadingScreen { get; set; }

    public static bool IsLoaded(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            var s = SceneManager.GetSceneAt(i);
            if (s.name == sceneName && s.isLoaded) return true;
        }
        return false;
    }

    public static async UniTask<PreloadedScene> PreloadAsync(
        string sceneName,
        LoadSceneMode mode = LoadSceneMode.Single,
        IProgress<float> progress = null,
        int priority = 0,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(sceneName)) throw new ArgumentException("Scene name is null/empty.");

        if (mode == LoadSceneMode.Additive && IsLoaded(sceneName))
        {
            progress?.Report(1f);
            LoadingScreen?.SetProgress(1f);
            return PreloadedScene.AlreadyLoaded(sceneName);
        }

        LoadingScreen.Show();

        var op = SceneManager.LoadSceneAsync(sceneName, mode);
        if (op == null) throw new InvalidOperationException($"Failed to start loading scene '{sceneName}'.");

        op.allowSceneActivation = false;
        op.priority = priority;

        while (op.progress < 0.9f)
        {
            ct.ThrowIfCancellationRequested();
            var p = Mathf.InverseLerp(0f, 0.9f, op.progress);
            progress?.Report(p);
            LoadingScreen?.SetProgress(p);
            await UniTask.Delay(10);
            await UniTask.Yield(PlayerLoopTiming.Update, ct);
        }

        progress?.Report(1f);
        LoadingScreen?.SetProgress(1f);

        return new PreloadedScene(sceneName, mode, op);
    }

    public static async UniTask<Scene> LoadAndActivateAsync(
        string sceneName,
        LoadSceneMode mode = LoadSceneMode.Single,
        IProgress<float> progress = null,
        int priority = 0,
        TimeSpan? activationTimeout = null,
        CancellationToken ct = default)
    {
        var preloaded = await PreloadAsync(sceneName, mode, progress, priority, ct);
        return await preloaded.ActivateAsync(activationTimeout, ct);
    }

    public static async UniTask UnloadAsync(
        string sceneName,
        string fallbackSceneIfActive = null,
        IProgress<float> progress = null,
        CancellationToken ct = default)
    {
        if (!IsLoaded(sceneName)) return;

        var scene = SceneManager.GetSceneByName(sceneName);
        if (scene == SceneManager.GetActiveScene())
        {
            if (!string.IsNullOrEmpty(fallbackSceneIfActive))
            {
                await LoadAndActivateAsync(fallbackSceneIfActive, LoadSceneMode.Single, progress, 0, null, ct);
            }
            else
            {
                throw new InvalidOperationException($"Cannot unload the active scene '{sceneName}' without a fallback.");
            }
        }

        var op = SceneManager.UnloadSceneAsync(scene);
        if (op == null) return;

        while (!op.isDone)
        {
            ct.ThrowIfCancellationRequested();
            progress?.Report(op.progress);
            LoadingScreen?.SetProgress(op.progress);
            await UniTask.Yield(PlayerLoopTiming.Update, ct);
        }

        await Resources.UnloadUnusedAssets();
    }

    public static async UniTask<Scene> SwitchAsync(
        string sceneName,
        IProgress<float> progress = null,
        int priority = 0,
        CancellationToken ct = default)
    {
        var scene = await LoadAndActivateAsync(sceneName, LoadSceneMode.Single, progress, priority, null, ct);
        
        LoadingScreen?.Hide();
        return scene;
    }

    public static Scene GetLoadedSceneOrThrow(string sceneName)
    {
        var scene = SceneManager.GetSceneByName(sceneName);
        if (!scene.IsValid() || !scene.isLoaded) throw new InvalidOperationException($"Scene '{sceneName}' is not loaded.");
        return scene;
    }

    public readonly struct PreloadedScene
    {
        public readonly string SceneName;
        public readonly LoadSceneMode Mode;
        private readonly AsyncOperation _op;
        private readonly bool _alreadyLoaded;

        public bool IsValid => _alreadyLoaded || _op != null;

        public PreloadedScene(string sceneName, LoadSceneMode mode, AsyncOperation op)
        {
            SceneName = sceneName;
            Mode = mode;
            _op = op;
            _alreadyLoaded = false;
        }

        private PreloadedScene(string sceneName, LoadSceneMode mode)
        {
            SceneName = sceneName;
            Mode = mode;
            _op = null;
            _alreadyLoaded = true;
        }

        public static PreloadedScene AlreadyLoaded(string sceneName) => new PreloadedScene(sceneName, LoadSceneMode.Additive);

        public async UniTask<Scene> ActivateAsync(TimeSpan? timeout = null, CancellationToken ct = default)
        {
            if (!IsValid) throw new InvalidOperationException("PreloadedScene is invalid.");

            if (_alreadyLoaded)
            {
                var already = SceneManager.GetSceneByName(SceneName);
                if (!already.IsValid()) throw new InvalidOperationException($"Scene '{SceneName}' was expected to be loaded but isn't.");
                SceneManager.SetActiveScene(already);
                return already;
            }

            _op.allowSceneActivation = true;

            if (timeout.HasValue)
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                cts.CancelAfter(timeout.Value);
                await _op.ToUniTask(cancellationToken: cts.Token);
            }
            else
            {
                await _op.ToUniTask(cancellationToken: ct);
            }

            var scene = SceneManager.GetSceneByName(SceneName);
            if (!scene.IsValid()) throw new InvalidOperationException($"Scene '{SceneName}' failed to activate.");

            if (Mode == LoadSceneMode.Single || !SceneManager.GetActiveScene().IsValid())
            {
                SceneManager.SetActiveScene(scene);
            }

            return scene;
        }
    }
}