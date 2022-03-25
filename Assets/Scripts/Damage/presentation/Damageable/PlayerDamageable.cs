using Health.domain;
using Photon.Pun;
using Zenject;

namespace Damage.presentation.Damageable
{
    public class PlayerDamageable : MonoBehaviourPun, IDamageable
    {
        [Inject] private DecreaseHealthUseCase decreaseHealthUseCase;

        public void TakeDamage(int damage) => photonView.RPC(nameof(RPC_TakeDamage), photonView.Controller, damage);

        public void RPC_TakeDamage(int damage)
        {
            if (!photonView.IsMine) return;
            decreaseHealthUseCase.DecreaseHealth(damage);
        }
    }
}