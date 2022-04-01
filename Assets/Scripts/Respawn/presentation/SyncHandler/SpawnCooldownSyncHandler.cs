using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using Respawn.domain.model;
using Respawn.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace Respawn.presentation.SyncHandler
{
    public class SpawnCooldownSyncHandler : MonoBehaviour, IOnEventCallback
    {
        private const byte CustomSpawnCooldownSyncEventCode = 8;
        [Inject] private ICurrentPlayerSpawnEventRepository playerSpawnEventRepository;
        [Inject] private ISpawnPointCooldownRepository spawnPointCooldownRepository;

        private void Awake() => playerSpawnEventRepository
            .GetSpawnEventFlow()
            .Subscribe(HandleSpawn)
            .AddTo(this);

        private void HandleSpawn(SpawnEvent spawnEvent)
        { 
            var data = new object[]
            {
                spawnEvent.PointId,
                spawnEvent.EventCooldown
            };

            //TODO: replace with reliable handler
            var raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.DoNotCache
            };

            var sendOptions = new SendOptions {Reliability = true};
            PhotonNetwork.RaiseEvent(CustomSpawnCooldownSyncEventCode, data, raiseEventOptions, sendOptions);
        }

        public void OnEvent(EventData photonEvent)
        {
            if (photonEvent.Code != CustomSpawnCooldownSyncEventCode) return;

            var data = (object[]) photonEvent.CustomData;
            spawnPointCooldownRepository.SetCooldown((int) data[0], (int) data[1]);
        }

        private void OnEnable() => PhotonNetwork.AddCallbackTarget(this);

        private void OnDisable() => PhotonNetwork.RemoveCallbackTarget(this);
    }
}