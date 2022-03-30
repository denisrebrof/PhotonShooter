using System.Linq;
using Photon.Pun;
using UnityEngine;

namespace Health.presentation.Legacy
{
    public class HealthUILegacy : MonoBehaviourPun
    {
        private Transform lookAt;
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private Transform healthTransform;

        private void Start()
        {
            if (photonView.IsMine)
                GetComponentsInChildren<MeshRenderer>().ToList().ForEach(rend => rend.enabled = false);
            lookAt = Camera.main.transform;
        }

        private void Update() => transform.LookAt(lookAt, Vector3.up);

        public void SetHealth(int health)
        {
            var scale = ((float) health) / maxHealth;
            healthTransform.localScale = new Vector3(scale, 1f, 1f);
        }
    }
}