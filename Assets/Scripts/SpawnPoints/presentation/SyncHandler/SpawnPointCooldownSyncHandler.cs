using Photon.Pun;
using Zenject;

namespace SpawnPoints.presentation.SyncHandler
{
    public class SpawnPointCooldownSyncHandler : MonoBehaviourPun, IPunObservable
    {
        // [Inject] private IHealthHandlersRepository healthHandlersRepository;
        // protected abstract string HandlerId { get; }
        // protected abstract int CurrentHealth { get; }
        //
        // public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        // {
        //     if (photonView.IsMine) SendHealth(stream);
        //     else ReceiveHealth(stream);
        // }
        //
        // private void SendHealth(PhotonStream stream)
        // {
        //     stream.SendNext(CurrentHealth);
        // }
        //
        // private void ReceiveHealth(PhotonStream stream)
        // {
        //     var health = (int) stream.ReceiveNext();
        //     healthHandlersRepository.SetHealth(HandlerId, health);
        // }
        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            throw new System.NotImplementedException();
        }
    }
}