using UnityEngine;

[CreateAssetMenu(menuName = "Rabidus/ScoreConfig")]
public class ScoreConfig : ScriptableObject, IScoreConfig
{
    [field: SerializeField] public int ScoreToAdd { get; private set; } = 1;
}
