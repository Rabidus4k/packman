using UnityEngine;

public interface IEnemyModel
{
    public IEnemyConfig Config { get; }
    public bool CanFollow { get; }
    void SetCanFollow(bool canFollow);
}
