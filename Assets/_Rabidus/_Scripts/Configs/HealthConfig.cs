using UnityEngine;

[CreateAssetMenu(menuName = "Rabidus/HealthConfig")]
public class HealthConfig : ScriptableObject, IHealthConfig
{
    [field: SerializeField] public int HealthToAdd { get; private set; } = 1;
}
