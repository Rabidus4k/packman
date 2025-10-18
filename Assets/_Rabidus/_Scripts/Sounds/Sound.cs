using UnityEngine;

[CreateAssetMenu(menuName = "Rabidus/Sound")]
public class Sound : ScriptableObject
{
    public AudioClip Clip;
    public float Volume = 1;
    public float Pitch = 1;
    public bool Loop = false;
    public float LifeTime = 3;
}
