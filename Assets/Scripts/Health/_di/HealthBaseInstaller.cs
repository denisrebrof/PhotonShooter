using Health.data;
using Health.domain;
using Health.domain.repositories;
using Health.presentation.HealthHandler;
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
            Container.Bind<IHealthHandlersRepository>().To<HealthHandlersImMemoryRepository>().AsSingle();
            //Presentation
            Container.Bind<PlayerHealthHandlerSyncAdapter>().ToSelf().AsSingle();
        }
    }
}
