using Health.data;
using Health.domain;
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
            Container.Bind<IHealthRepository>().To<InMemoryHealthRepository>().AsSingle();
        }
    }
}