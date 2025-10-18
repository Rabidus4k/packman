using UnityEngine;

[CreateAssetMenu(menuName = "Rabidus/EnemyConfig")]
public class EnemyConfig : ScriptableObject
{
    [Min(0f)] public float MoveSpeed = 5f;
    [Min(0f)] public float RotationSpeed = 180f;
    [Min(0f)] public float VisionDistance = 4f;
    [Min(0)] public int Damage = 1;
}
