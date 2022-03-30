using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;
using static Health.presentation.Legacy.ShootEffectLegacy.HitEffectType;

namespace Health.presentation.Legacy
{
    public class SimpleShootingLegacy : MonoBehaviourPun
    {
        private Camera cam;
        [SerializeField] private ParticleSystem shootPart;
        [SerializeField] private ShootEffectLegacy shootEffectLegacy;
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

        private void Shoot()
        {
            ShootEffect();
            var ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            ray.origin = cam.transform.position;
            var sourceTransform = shootPart.transform;
            if (!Physics.Raycast(ray, out RaycastHit hit))
            {
                var position = sourceTransform.position;
                shootEffectLegacy.HandleShoot(position, position + cam.transform.forward * 10f, None);
                return;
            }

            var health = hit.collider.gameObject.GetComponent<HealthHandlerLegacy>();
            if (health != null) health.TakeDamage(10);

            shootEffectLegacy.HandleShoot(sourceTransform.position, hit.point, health != null ? Player : Ground);
        }

        private void ShootEffect()
        {
            photonView.RPC(nameof(RPC_ShootEffect), RpcTarget.All);
        }

        [PunRPC]
        public void RPC_ShootEffect()
        {
            onShoot.Invoke();
            shootPart.Play();
        }
    }
}