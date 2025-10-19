using Zenject;

public class EnemyDamageModel : IEnemyDamageModel
{
    public IEnemyConfig Config { get; private set; }

    public EnemyDamageModel(IEnemyConfig config)
    {
        Config = config;
    }
}
