using System;
using System.Collections.Generic;
using Photon.Lobby.domain;
using Photon.Realtime;
using UniRx;
using UnityEngine;
using Zenject;

namespace Photon.Lobby.presentation
{
    public class RoomList : MonoBehaviour
    {
        [SerializeField] private Transform listRoot;
        [Inject] private IRoomListRepository roomListRepository;
        private IDisposable updateCountDisposable;

        private int pageIndex = 0;
        private List<IRoomListItem> items = new();

        public void SetPageIndex(int index)
        {
            pageIndex = index;
            HandleList(roomListRepository.GetRoomsList());
        }

        private void Awake()
        {
            items.AddRange(listRoot.GetComponentsInChildren<IRoomListItem>());
            items.ForEach(item => item.SetActive(false));
        }

        private void OnEnable() => updateCountDisposable = roomListRepository
            .GetRoomsListFlow()
            .Subscribe(HandleList)
            .AddTo(this);

        private void HandleList(List<RoomInfo> rooms)
        {
            var pageStart = Math.Max(pageIndex * items.Count, rooms.Count - 1);
            var pageEnd = Math.Min((pageIndex + 1) * items.Count, rooms.Count);
            pageEnd = Math.Max(pageEnd, 0);

            var pagedRooms = rooms.GetRange(pageStart, pageEnd - pageStart);
            for(var i=0; i<items.Count;i++)
            {
                var active = pagedRooms.Count > i;
                items[i].SetActive(active);
                if(!active) continue;
                items[i].Setup(pagedRooms[i]);
            }
        }

        private void OnDisable() => updateCountDisposable.Dispose();

        public interface IRoomListItem
        {
            void Setup(RoomInfo info);
            void SetActive(bool active);
        }
    }
}