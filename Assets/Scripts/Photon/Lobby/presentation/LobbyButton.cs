using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Lobby.presentation
{
    [RequireComponent(typeof(Button))]
    public class LobbyButton : MonoBehaviourPunCallbacks
    {
        private Button button;

        private Button Button
        {
            get
            {
                if (button == null) button = GetComponent<Button>();
                return button;
            }
        }

        public override void OnEnable()
        {
            base.OnEnable();
            Button.interactable = PhotonNetwork.IsConnected;
        }

        public override void OnJoinedLobby()
        {
            base.OnJoinedLobby();
            Button.interactable = false;
        }

        public override void OnLeftLobby()
        {
            base.OnLeftLobby();
            Button.interactable = PhotonNetwork.IsConnected;
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Button.interactable = true;
        }
    }
}