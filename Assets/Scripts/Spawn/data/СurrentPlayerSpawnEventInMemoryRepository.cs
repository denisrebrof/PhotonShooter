using System;
using Spawn.domain.model;
using Spawn.domain.repositories;
using UniRx;

namespace Spawn.data
{
    public class СurrentPlayerSpawnEventInMemoryRepository : ICurrentPlayerSpawnEventRepository
    {
        private readonly Subject<SpawnEvent> spawnPointSubject = new();
        void ICurrentPlayerSpawnEventRepository.AddSpawnEvent(SpawnEvent spawnEvent) => spawnPointSubject.OnNext(spawnEvent);
        IObservable<SpawnEvent> ICurrentPlayerSpawnEventRepository.GetSpawnEventFlow() => spawnPointSubject;
    }
}