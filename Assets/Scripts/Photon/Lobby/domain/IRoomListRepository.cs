using System;
using System.Collections.Generic;
using Photon.Realtime;
using UniRx;

namespace Photon.RoomList.domain
{
    public interface IRoomListRepository
    {
        IObservable<List<RoomInfo>> GetRoomsListFlow();
        List<RoomInfo> GetRoomsList();
    }
}