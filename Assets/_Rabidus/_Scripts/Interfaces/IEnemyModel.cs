using UnityEngine;

public interface IEnemyModel
{
    //Configs
    public EnemyConfig Config { get; }

    public Vector3 TargetPosition { get; }
    public bool CanFollow { get; }
    void SetTargetPosition(Vector3 position);
    void SetCanFollow(bool canFollow);
}
