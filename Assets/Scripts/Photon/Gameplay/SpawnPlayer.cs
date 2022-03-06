using Photon.Pun;
using UnityEngine;

namespace Photon.Gameplay
{
    public class SpawnPlayer : MonoBehaviour
    {
        public GameObject playerPrefab;

        private void Start()
        {
            var spawnTransform = transform;
            PhotonNetwork.Instantiate(this.playerPrefab.name, spawnTransform.position, spawnTransform.rotation);
        }
    }
}