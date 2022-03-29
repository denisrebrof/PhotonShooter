using Shooting.data;
using Shooting.domain;
using UnityEngine;
using Zenject;

namespace Shooting._di
{
    [CreateAssetMenu(fileName = "ShootingBaseInstaller", menuName = "Installers/ShootingBaseInstaller")]
    public class ShootingBaseInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            //Data
            Container.Bind<IShootingRepository>().To<ShootsInMemoryRepository>().AsSingle();
        }
    }
}