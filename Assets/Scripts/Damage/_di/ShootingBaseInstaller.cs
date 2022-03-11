using UnityEngine;
using Zenject;

namespace Shooting._di
{
    [UnityEngine.CreateAssetMenu(fileName = "ShootingBaseInstaller", menuName = "Installers/ShootingBaseInstaller", order = 0)]
    public class ShootingBaseInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            base.InstallBindings();
        }
    }
}