using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Rooms
{
    [RequireComponent(typeof(Button))]
    public class JoinRandomButton : MonoBehaviourPunCallbacks
    {
        private Button button;
        private bool connected = false;

        public override void OnEnable()
        {
            base.OnEnable();
            if (button == null)
            {
                button = GetComponent<Button>();
                button.onClick.AddListener(Click);
            }
            SetConnected(PhotonNetwork.IsConnected);
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            SetConnected(true);
        }

        public override void OnJoinedLobby() => SetConnected(false);

        public override void OnLeftLobby() => SetConnected(true);

        private void SetConnected(bool isConnected)
        {
            connected = isConnected;
            button.interactable = isConnected;
        }

        private void Click()
        {
            if(!connected) return;
            PhotonNetwork.JoinRandomOrCreateRoom(
                roomOptions: new RoomOptions()
                {
                    PublishUserId = true
                }
                );
        }
    }
}
