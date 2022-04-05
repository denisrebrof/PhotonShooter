﻿using Health.domain.repositories;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Health.presentation.SyncHandler
{
    public abstract class HealthSyncHandler : MonoBehaviourPun, IPunObservable
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
        }
    }
}