using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Photon.Room
{
    [RequireComponent(typeof(Button))]
    public class CreateRoomButton : MonoBehaviour
    {
        private void Start() => GetComponent<Button>().onClick.AddListener(CreateRoom);

        private static void CreateRoom()
        {
            PhotonNetwork.CreateRoom("def");
        }
    }
}
