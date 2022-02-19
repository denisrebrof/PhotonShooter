using Photon.Player.PlayerState.data;
using Photon.Player.PlayerState.domain;
using UnityEngine;
using Zenject;

namespace Photon.Player.PlayerState._di
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