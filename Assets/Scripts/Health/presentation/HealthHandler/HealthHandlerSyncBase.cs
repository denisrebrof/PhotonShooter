using Health.domain.repositories;
using JetBrains.Annotations;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Health.presentation.HealthHandler
{
    public abstract class HealthHandlerSyncBase : MonoBehaviourPun, IPunObservable
    {
        [Inject] private IHealthHandlersRepository healthHandlersRepository;
        protected abstract string HandlerId { get; }
        protected abstract int CurrentHealth { get; }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (photonView.IsMine) SendHealth(stream);
            else ReceiveHealth(stream);
        }

        private void SendHealth(PhotonStream stream)
        {
            stream.SendNext(CurrentHealth);
        }

        private void ReceiveHealth(PhotonStream stream)
        {
            var health = (int) stream.ReceiveNext();
            healthHandlersRepository.SetHealth(HandlerId, health);
            Debug.Log("Receive Health: " + health + " HandlerId: " + HandlerId);
        }
    }
}