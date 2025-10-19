using UnityEngine;

public interface ICharacterConfig
{
    public float MoveSpeed { get; }
    public float RotationSpeed { get; }
    public int MaxHealth { get; }
}
