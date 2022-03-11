using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

namespace Health.presentation
{
    public class HealthHandler : MonoBehaviourPun
    {
        [SerializeField]
        private int health = 100;
        public UnityEvent<int> healthChanged;
        public UnityEvent damageTaken;

        private void Start()
        {
            healthChanged.Invoke(health);
        }

        public void Reset()
        {
            health = 100;
            healthChanged.Invoke(health);
        }

        public void TakeDamage(int damage)
        {
            damageTaken.Invoke();
            photonView.RPC(nameof(RPC_TakeDamage), RpcTarget.All, damage);
        }

        [PunRPC]
        public void RPC_TakeDamage(int damage)
        {
            if(!photonView.IsMine) return;

            health -= damage;
            healthChanged.Invoke(health);
        }
    }
}
