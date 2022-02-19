using Photon.RoomList.data;
using Photon.RoomList.domain;
using UnityEngine;
using Zenject;

namespace Photon.RoomList._di
{
    public class RoomListBaseInstaller : MonoInstaller
    {
        [SerializeField] private PhotonRoomListRepository roomListRepository;
        public override void InstallBindings()
        {
            base.InstallBindings();
            Container.Bind<IRoomListRepository>().FromInstance(roomListRepository).AsSingle();
        }
    }
}