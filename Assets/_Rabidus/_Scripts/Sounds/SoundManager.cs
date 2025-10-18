using Lean.Pool;
using UnityEngine;
using VInspector;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] private AudioSource _audioSourcePrefab;
    
    [field : SerializeField] public SerializedDictionary<string, Sound> DefaultSounds { get; private set; } = new SerializedDictionary<string, Sound>();
    
    public void PlaySound(string sound)
    {
        if (!DefaultSounds.ContainsKey(sound))
        {
            Debug.LogWarning($"[PlaySound] No such sound: {sound}");
            return;
        }

        Sound selectedSound = DefaultSounds[sound];
        PlaySound(selectedSound);
    }

    public void PlaySound(Sound sound)
    {
        var audioSource = LeanPool.Spawn(_audioSourcePrefab);
        audioSource.clip = sound.Clip;
        audioSource.volume = sound.Volume;
        audioSource.loop = sound.Loop;
        audioSource.pitch = sound.Pitch;

        audioSource.Play();

        LeanPool.Despawn(audioSource, sound.LifeTime);
    }
}
