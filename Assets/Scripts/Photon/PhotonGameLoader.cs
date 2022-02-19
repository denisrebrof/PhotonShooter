using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Photon
{
    public class PhotonGameLoader : MonoBehaviourPunCallbacks
    {
        public override void OnConnectedToMaster() => PhotonNetwork.AutomaticallySyncScene = true;

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined Room");
            if(PhotonNetwork.IsMasterClient)
                PhotonNetwork.LoadLevel(1);
        }
        
        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            if(newMasterClient.IsMasterClient)
                PhotonNetwork.LoadLevel(1);
        }
    }
}
