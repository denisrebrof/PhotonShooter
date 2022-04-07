using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Photon
{
    public class ConnectedIndicator : MonoBehaviourPunCallbacks
    {
        [SerializeField] private string connectedCaption = "Ready!";
        [SerializeField] private string notConnectedCaption = "Connecting...";
        [SerializeField] private Text connectionStateText;

        public override void OnEnable()
        {
            base.OnEnable();
            SetConnected(PhotonNetwork.IsConnectedAndReady);
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            SetConnected(true);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            base.OnDisconnected(cause);
            SetConnected(false);
        }

        private void SetConnected(bool connected)
        {
            connectionStateText.text = connected ? connectedCaption : notConnectedCaption;
        }
    }
}