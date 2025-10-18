public class EnemySpyModel : EnemyModel, IEnemySpyModel
{
    public bool CanSee {get; private set;}

    public void SetCanSee(bool canSee)
    {
        CanSee = canSee;
    }
}
