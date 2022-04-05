using Health.data;
using Health.domain;
using Health.domain.repositories;
using UnityEngine;
using Zenject;

namespace Health._di
{
    [CreateAssetMenu(fileName = "HealthBaseInstaller", menuName = "Installers/HealthBaseInstaller", order = 0)]
    public class HealthBaseInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            Container.Bind<IMaxHealthRepository>().To<DefaultOneHundredMaxHealthRepository>().AsSingle();
            Container.Bind<ICurrentPlayerHealthRepository>().To<InMemoryCurrentPlayerHealthRepository>().AsSingle();
            Container.Bind<IHealthHandlersRepository>().To<HealthHandlersInMemoryRepository>().AsSingle();
            //Presentation
            Container.Bind<DecreaseHealthUseCase>().ToSelf().AsSingle();
            Container.Bind<IncreaseHealthUseCase>().ToSelf().AsSingle();
            Container.Bind<RestoreHealthUseCase>().ToSelf().AsSingle();
            Container.Bind<RelativeHealthUseCase>().ToSelf().AsSingle();
            Container.Bind<CurrentPlayerDeathEventUseCase>().ToSelf().AsSingle();
        }
    }
}
