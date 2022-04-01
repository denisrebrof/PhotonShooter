using System;
using Respawn.domain.model;
using Respawn.domain.repositories;
using UniRx;

namespace Respawn.data
{
    public class СurrentPlayerSpawnEventInMemoryRepository : ICurrentPlayerSpawnEventRepository
    {
        private readonly Subject<SpawnEvent> spawnPointSubject = new();
        void ICurrentPlayerSpawnEventRepository.AddSpawnEvent(SpawnEvent spawnEvent) => spawnPointSubject.OnNext(spawnEvent);
        IObservable<SpawnEvent> ICurrentPlayerSpawnEventRepository.GetSpawnEventFlow() => spawnPointSubject;
    }
}