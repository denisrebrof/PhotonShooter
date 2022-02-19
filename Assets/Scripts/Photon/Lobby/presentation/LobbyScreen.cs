using Photon.Pun;
using UnityEngine;

namespace Photon.Lobby.presentation
{
    public class LobbyScreen : MonoBehaviourPunCallbacks
    {
        public override void OnEnable()
        {
            base.OnEnable();
            if (PhotonNetwork.InLobby || !PhotonNetwork.IsConnectedAndReady) return;
            PhotonNetwork.JoinLobby();
            Debug.Log("Join Lobby");
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            if (!PhotonNetwork.InLobby)
                PhotonNetwork.JoinLobby();
        }

        public override void OnDisable()
        {
            base.OnDisable();
            if (!PhotonNetwork.InLobby) return;
            PhotonNetwork.LeaveLobby();
            Debug.Log("Leave Lobby");
        }
    }
}