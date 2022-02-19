using Photon.Pun;
using UnityEngine;

namespace Photon
{
    public class PhotonLauncher : MonoBehaviour
    {
        private void Start()
        {
            if(PhotonNetwork.IsConnected) return;
            Debug.Log("Connecting to Master ...");
            PhotonNetwork.ConnectUsingSettings();
            DontDestroyOnLoad(gameObject);
        }
    }
}