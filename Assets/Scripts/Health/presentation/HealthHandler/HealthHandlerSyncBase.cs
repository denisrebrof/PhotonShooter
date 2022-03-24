using Health.domain.repositories;
using JetBrains.Annotations;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Health.presentation.HealthHandler
{
    public abstract class HealthHandlerSyncBase : MonoBehaviourPun, IPunObservable
    {
        [CanBeNull] private IHealthHandlerSyncAdapter handlerSyncAdapter;
        [Inject] private IHealthHandlersRepository healthHandlersRepository;
        protected abstract string HandlerId { get; }

        private void Awake()
        {
            if (!SetupAdapter(out handlerSyncAdapter)) 
                Debug.LogError("HealthHandler adapter not found!");
        }

        protected virtual bool SetupAdapter(out IHealthHandlerSyncAdapter syncAdapter) => TryGetComponent(out syncAdapter);

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (photonView.IsMine) SendHealth(stream);
            else ReceiveHealth(stream);
        }

        private void SendHealth(PhotonStream stream)
        {
            if (handlerSyncAdapter != null)
                stream.SendNext(handlerSyncAdapter.CurrentHealth);
            else
                Debug.LogError("HealthHandler needs adapter to sync data!");
        }

        private void ReceiveHealth(PhotonStream stream)
        {
            var health = (int) stream.ReceiveNext();
            healthHandlersRepository.SetHealth(HandlerId, health);
        }

        public interface IHealthHandlerSyncAdapter
        {
            int InitialHealth { get; }
            int CurrentHealth { get; }
        }
    }
}