using UnityEngine;

[CreateAssetMenu(menuName = "Rabidus/CharacterConfig")]
public class CharacterConfig : ScriptableObject, ICharacterConfig
{
    [field: SerializeField, Min(0f)] public float MoveSpeed { get; private set; } = 5f;
    [field: SerializeField, Min(0f)] public float RotationSpeed { get; private set; } = 180f;
    [field: SerializeField, Min(0f)] public int MaxHealth { get; private set; } = 3;
}
