using Photon.Pun;
using Shooting.domain;
using Shooting.domain.model;
using UniRx;
using Zenject;

namespace Shooting.presentation.SyncHandler
{
    public abstract class ShootingHandlerSyncBase : MonoBehaviourPun
    {
        [Inject] private IShootingRepository shootingRepository;
        protected abstract string HandlerId { get; }

        private void Awake()
        {
            if (!photonView.IsMine) return;

            shootingRepository
                .GetShotsFlow(HandlerId)
                .Subscribe(_ => InvokeShoot())
                .AddTo(this);
        }

        private void InvokeShoot() => photonView.RPC(nameof(RPC_InvokeShoot), RpcTarget.Others);

        [PunRPC]
        public void RPC_InvokeShoot()
        {
            var shoot = new Shoot(HandlerId);
            shootingRepository.AddShoot(shoot);
        }
    }
}