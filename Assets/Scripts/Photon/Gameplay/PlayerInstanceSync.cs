using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Photon.Gameplay
{
    public class PlayerInstanceSync : MonoBehaviour, IOnEventCallback
    {
        private const byte CustomManualInstantiationEventCode = 7;
        [SerializeField] private GameObject playerSourcePrefab;
        [SerializeField] private GameObject playerViewPrefab;

        private void Start() => SpawnPlayerPrefab();

        private void SpawnPlayerPrefab()
        {
            var spawnTransform = transform;
            var player = Instantiate(playerSourcePrefab, spawnTransform.position, spawnTransform.rotation);
            var photonView = player.GetComponent<PhotonView>();

            if (!PhotonNetwork.AllocateViewID(photonView))
            {
                Debug.LogError("Failed to allocate a ViewId.");
                Destroy(player);
            }

            var data = new object[]
            {
                player.transform.position,
                player.transform.rotation,
                photonView.ViewID
            };

            var raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.AddToRoomCache
            };

            var sendOptions = new SendOptions {Reliability = true};
            PhotonNetwork.RaiseEvent(CustomManualInstantiationEventCode, data, raiseEventOptions, sendOptions);
        }

        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code != CustomManualInstantiationEventCode) return;

            var data = (object[]) photonEvent.CustomData;
            var player = Instantiate(playerViewPrefab, (Vector3) data[0], (Quaternion) data[1]);
            var photonView = player.GetComponent<PhotonView>();
            photonView.ViewID = (int) data[2];
        }

        private void OnEnable() => PhotonNetwork.AddCallbackTarget(this);

        private void OnDisable() => PhotonNetwork.RemoveCallbackTarget(this);
    }
}