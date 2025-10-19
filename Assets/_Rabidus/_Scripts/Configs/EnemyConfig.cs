using UnityEngine;

[CreateAssetMenu(menuName = "Rabidus/EnemyConfig")]
public class EnemyConfig : ScriptableObject, IEnemyConfig
{
    [field: SerializeField, Min(0f)] public float MoveSpeed { get; private set; } = 5f;
    [field: SerializeField, Min(0f)] public float RotationSpeed { get; private set; } = 180f;
    [field: SerializeField, Min(0f)] public float VisionDistance { get; private set; } = 4f;
    [field: SerializeField, Min(0)] public int Damage { get; private set; } = 1;
}
