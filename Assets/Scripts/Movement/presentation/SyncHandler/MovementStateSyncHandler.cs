using Movement.domain;
using Movement.domain.model;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Movement.presentation.SyncHandler
{
    public abstract class MovementStateSyncHandler : MonoBehaviourPun, IPunObservable
    {
        [Inject] private IMovementStateRepository movementStateRepository;
        protected abstract string HandlerId { get; }
        protected abstract MovementState CurrentState { get; }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (photonView.IsMine) SendState(stream);
            else ReceiveState(stream);
        }

        private void SendState(PhotonStream stream)
        {
            stream.SendNext(CurrentState.XAxis);
            stream.SendNext(CurrentState.YAxis);
            stream.SendNext(CurrentState.Jumping);
        }

        private void ReceiveState(PhotonStream stream)
        {
            var XAxis = (int) stream.ReceiveNext();
            var YAxis = (int) stream.ReceiveNext();
            var Jumping = (bool) stream.ReceiveNext();
            movementStateRepository.SetMovementState(HandlerId, new MovementState(XAxis,YAxis, Jumping));
        }
    }
}