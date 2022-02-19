using System;
using System.Linq;
using Photon.RoomList.domain;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Photon.RoomList.presentation
{
    [RequireComponent(typeof(Text))]
    public class RoomListCounterText : MonoBehaviour
    {
        [Inject] private IRoomListRepository roomListRepository;
        private IDisposable updateCountDisposable;

        private void OnEnable()
        {
            var text = GetComponent<Text>();
            updateCountDisposable = roomListRepository
                .GetRoomsListFlow()
                .Select(list => list.Count())
                .DistinctUntilChanged()
                .Subscribe(count => text.text = count.ToString())
                .AddTo(this);
        }

        private void OnDisable() => updateCountDisposable.Dispose();
    }
}