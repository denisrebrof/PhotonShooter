using System;
using System.Collections.Generic;
using System.Linq;
using Photon.Lobby.domain;
using Photon.Pun;
using Photon.Realtime;
using UniRx;

namespace Photon.Lobby.data
{
    public class PhotonRoomListRepository : MonoBehaviourPunCallbacks, IRoomListRepository
    {
        private readonly Subject<bool> joinedLobbyState = new();
        private static readonly List<RoomInfo> EmptyList = new();
        private readonly ReactiveProperty<List<RoomInfo>> rooms = new(EmptyList);

        IObservable<List<RoomInfo>> IRoomListRepository.GetRoomsListFlow() => rooms
            .CombineLatest(joinedLobbyState, (list, state) => state ? list : EmptyList);

        public override void OnJoinedLobby() => joinedLobbyState.OnNext(true);

        public override void OnLeftLobby() => joinedLobbyState.OnNext(false);

        public override void OnRoomListUpdate(List<RoomInfo> roomList) => rooms.Value = roomList
            .Where(room => !room.RemovedFromList)
            .ToList();

        public List<RoomInfo> GetRoomsList() => rooms.Value;

        //Photon requires it, don't delete ???
        public override void OnEnable() => base.OnEnable();

        public override void OnDisable() => base.OnDisable();
    }
}