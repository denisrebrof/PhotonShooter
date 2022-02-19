using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Photon
{
    public class ConnectedIndicator : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject connectionMark;

        public override void OnEnable()
        {
            base.OnEnable();
            connectionMark.SetActive(!PhotonNetwork.IsConnectedAndReady);
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            connectionMark.SetActive(false);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            connectionMark.SetActive(true);
        }
    }
}
