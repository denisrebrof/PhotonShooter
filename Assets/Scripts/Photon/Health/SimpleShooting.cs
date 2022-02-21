using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

namespace Photon.Health
{
    public class SimpleShooting: MonoBehaviourPun
    {
        private Camera cam;
        [SerializeField]
        private ParticleSystem shootPart;
        public UnityEvent onShoot;

        private void Start()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && photonView.IsMine)
                Shoot();
        }

        void Shoot()
        {
            onShoot.Invoke();
            ShootEffect();
            var ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            ray.origin = cam.transform.position;
            if(Physics.Raycast(ray, out RaycastHit hit))
                hit.collider.gameObject.GetComponent<HealthHandler>()?.TakeDamage(10);
        }
        
        void ShootEffect()
        {
            photonView.RPC("RPC_ShootEffect", RpcTarget.All);
        }

        [PunRPC]
        public void RPC_ShootEffect()
        {
            shootPart.Play();
        }
    }
}