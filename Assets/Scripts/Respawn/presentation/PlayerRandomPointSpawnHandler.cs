using System;
using Respawn.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Respawn.presentation
{
    public class PlayerRandomPointSpawnHandler : MonoBehaviour
    {
        [Inject] private SpawnCurrentPlayerAvailableUseCase spawnCurrentPlayerAvailableUseCase;
        [Inject] private RandomOrFirstAvailableSpawnPointUseCase randomOrFirstAvailableSpawnPointUseCase;
        [Inject] private SpawnCurrentPlayerUseCase spawnCurrentPlayerUseCase;

        private void Awake() => spawnCurrentPlayerAvailableUseCase
            .GetSpawnAvailableFlow()
            .Do(spawnAvailable => Debug.Log("Spawn Avaliable: " + spawnAvailable))
            .Select(GetSpawnPointId)
            .Switch()
            // .Delay(TimeSpan.FromSeconds(0.5))
            .Subscribe(TryAutoSpawn)
            .AddTo(this);

        private IObservable<int> GetSpawnPointId(bool spawnAvailable) => spawnAvailable
            ? randomOrFirstAvailableSpawnPointUseCase.GetSpawnPointId()
            : Observable.Empty<int>();

        private void TryAutoSpawn(int pointId) => spawnCurrentPlayerUseCase.Spawn(pointId);
    }
}