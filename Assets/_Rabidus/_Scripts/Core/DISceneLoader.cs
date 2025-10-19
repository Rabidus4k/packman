using System;
using UnityEngine;
using Zenject;

public class DISceneLoader : MonoInstaller
{
    [SerializeField] private CharacterConfig _characterConfig;

    [SerializeField] private EnemyConfig _enemyConfig;

    public override void InstallBindings()
    {
        PlayerBindings();
        EnemyBindgings();
    }

    private void PlayerBindings()
    {
        Container.Bind<ICharacterConfig>().FromInstance(_characterConfig);

        Container.Bind<ICharacterInputModel>().To<CharacterInputModel>().AsSingle();
        Container.Bind<ICharacterHealthModel>().To<CharacterHealthModel>().AsSingle();
        Container.Bind<ICharacterScoreModel>().To<CharacterScoreModel>().AsSingle();

        Container.Bind<ICharacterInputViewModel>().To<CharacterInputViewModel>().AsSingle();
        Container.Bind<ICharacterHealthViewModel>().To<CharacterHealthViewModel>().AsSingle();
        Container.Bind<IScoreViewModel>().To<ScoreViewModel>().AsSingle();
    }

    private void EnemyBindgings()
    {
        Container.Bind<IEnemyConfig>().FromInstance(_enemyConfig);

        Container.Bind<IEnemyModel>().To<EnemyModel>().AsTransient();
        Container.Bind<IEnemyDamageModel>().To<EnemyDamageModel>().AsTransient();
        Container.Bind<IEnemyPatrolModel>().To<EnemyPatrolModel>().AsTransient();
        Container.Bind<IEnemySpyModel>().To<EnemySpyModel>().AsTransient();
        

        Container.Bind<IEnemyViewModel>().To<EnemyViewModel>().AsTransient();
        Container.Bind<IEnemyDamageViewModel>().To<EnemyDamageViewModel>().AsTransient();
        Container.Bind<IEnemyPatrolViewModel>().To<EnemyPatrolViewModel>().AsTransient();
        Container.Bind<IEnemySpyViewModel>().To<EnemySpyViewModel>().AsTransient();
    }
}
