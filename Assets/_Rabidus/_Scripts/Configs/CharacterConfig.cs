using UnityEngine;

[CreateAssetMenu(menuName = "Rabidus/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [Min(0f)] public float MoveSpeed = 5f;
    [Min(0f)] public float RotationSpeed = 180f;
    [Min(0f)] public int MaxHealth = 3;
}
