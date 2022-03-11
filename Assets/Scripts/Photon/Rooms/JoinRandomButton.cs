using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Room
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
            PhotonNetwork.JoinRandomOrCreateRoom();
        }
    }
}
