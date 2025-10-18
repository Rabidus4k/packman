using UnityEngine;

public interface IEnemyDamageViewModel
{
    public ReactiveProperty<int> Damage { get; }
}
