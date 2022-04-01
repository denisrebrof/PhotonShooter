using Photon.Lobby.data;
using Photon.Lobby.domain;
using UnityEngine;
using Zenject;

namespace Photon.Lobby._di
{
    public class RoomListMonoInstaller : MonoInstaller
    {
        [SerializeField] private PhotonRoomListRepository roomListRepository;
        public override void InstallBindings()
        {
            Container.Bind<IRoomListRepository>().FromInstance(roomListRepository).AsSingle();
        }
    }
}