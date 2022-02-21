using System.Collections;
using System.Collections.Generic;
using Photon.Health;
using Photon.Pun;
using UnityEngine;

public class Respawn : MonoBehaviourPun
{
    // Start is called before the first frame update
    void Start()
    {
        if(!photonView.IsMine) return;
        GetComponent<HealthHandler>().healthChanged.AddListener(HandleHealth);
    }

    private void HandleHealth(int health)
    {
        if(health>0)
            return;

        GetComponent<HealthHandler>().Reset();
        photonView.transform.position = GameObject.Find("Respawn").transform.position;
    }
}
