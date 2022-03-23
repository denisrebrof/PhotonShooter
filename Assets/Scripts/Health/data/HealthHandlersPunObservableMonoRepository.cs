using System;
using System.Collections.Generic;
using System.Linq;
using Health.domain.repositories;
using Photon.Pun;
using UniRx;
using Utils;

namespace Health.data
{
    public class HealthHandlersPunObservableMonoRepository : MonoBehaviourPun, IPunObservable, IHealthHandlersRepository
    {
        private ReactiveDictionary<string, int> handlerIdToHealthMap = new();

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
                stream.WriteDictionary(handlerIdToHealthMap);
            else
                stream.ReceiveDictionary<string, int>(handlerIdToHealthMap.SetIfNotChanged);
        }

        public int GetHealth(string handlerId)
        {
            
        }

        public void SetHealth(string handlerId, int health) => photonView.RPC(
            nameof(RPC_SetHealth),
            photonView.Controller,
            handlerId,
            health
        );

        public void RPC_SetHealth(string handlerId, int health)
        {
            
        }

        public IObservable<int> GetHealthFlow(string handlerId)
        {
        }
    }
}