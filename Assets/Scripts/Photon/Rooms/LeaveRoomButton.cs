using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Photon.Room
{
    [RequireComponent(typeof(Button))]
    public class LeaveRoomButton : MonoBehaviourPunCallbacks
    {
        private void Start() => GetComponent<Button>().onClick.AddListener(LeaveRoom);

        private static void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }
    }
}
