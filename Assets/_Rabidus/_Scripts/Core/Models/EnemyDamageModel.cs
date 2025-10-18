public class EnemyDamageModel : IEnemyDamageModel
{
    public EnemyConfig Config { get; private set; }

    public void Initialize(EnemyConfig config)
    {
        Config = config;
    }
}
