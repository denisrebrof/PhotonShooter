using System;
using System.Collections.Generic;
using Photon.Realtime;

namespace Photon.Lobby.domain
{
    public interface IRoomListRepository
    {
        IObservable<List<RoomInfo>> GetRoomsListFlow();
        List<RoomInfo> GetRoomsList();
    }
}