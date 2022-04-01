using System;
using Respawn.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Respawn.presentation
{
    public class PlayerAutoSpawn : MonoBehaviour
    {
        [Inject] private SpawnCurrentPlayerAvailableUseCase spawnCurrentPlayerAvailableUseCase;
        [Inject] private RandomOrFirstAvailableSpawnPointUseCase randomOrFirstAvailableSpawnPointUseCase;
        [Inject] private SpawnCurrentPlayerUseCase spawnCurrentPlayerUseCase;

        private void Awake() => spawnCurrentPlayerAvailableUseCase
            .GetSpawnAvailableFlow()
            .Select(GetSpawnPointId)
            .Switch()
            .Subscribe(TryAutoSpawn)
            .AddTo(this);

        private IObservable<int> GetSpawnPointId(bool spawnAvailable) => spawnAvailable
            ? randomOrFirstAvailableSpawnPointUseCase.GetSpawnPointId()
            : Observable.Empty<int>();

        private void TryAutoSpawn(int pointId) => spawnCurrentPlayerUseCase.TrySpawn(pointId);
    }
}