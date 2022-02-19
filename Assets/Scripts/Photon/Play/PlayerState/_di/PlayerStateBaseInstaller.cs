using Photon.Play.PlayerState.data;
using Photon.Play.PlayerState.domain;
using UnityEngine;
using Zenject;

namespace Photon.Play.PlayerState._di
{
    [CreateAssetMenu(menuName = "Installers/PlayerStateBaseInstaller")]
    public class PlayerStateBaseInstaller: ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerStateRepository>().To<PlayerStateInMemoryRepository>().AsSingle();
        }
    }
}