using Photon.RoomList.data;
using Photon.RoomList.domain;
using UnityEngine;
using Zenject;

namespace Photon.RoomList._di
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