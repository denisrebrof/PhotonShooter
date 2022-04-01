using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Lobby.presentation
{
    public class RoomListItem : MonoBehaviour, RoomList.IRoomListItem
    {
        [SerializeField] private Text roomName;
        [SerializeField] private Text playersCount;

        public void Setup(RoomInfo info)
        {
            roomName.text = info.Name;
            playersCount.text = info.PlayerCount + " / " + info.MaxPlayers;
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }
    }
}