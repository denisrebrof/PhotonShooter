using Photon.Pun;
using UnityEngine;

namespace Health.presentation.Legacy
{
    public class RespawnLegacy : MonoBehaviourPun
    {
        // Start is called before the first frame update
        void Start()
        {
            if(!photonView.IsMine) return;
            GetComponent<HealthHandlerLegacy>().healthChanged.AddListener(HandleHealth);
        }

        private void HandleHealth(int health)
        {
            if(health>0)
                return;

            GetComponent<HealthHandlerLegacy>().Reset();
            photonView.transform.position = GameObject.Find("Respawn").transform.position;
        }
    }
}
