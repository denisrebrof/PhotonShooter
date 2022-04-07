using System;
using Spawn.domain.model;

namespace Spawn.domain.repositories
{
    public interface ICurrentPlayerSpawnEventRepository
    {
        internal void AddSpawnEvent(SpawnEvent spawnEvent);
        public IObservable<SpawnEvent> GetSpawnEventFlow();
    }
}