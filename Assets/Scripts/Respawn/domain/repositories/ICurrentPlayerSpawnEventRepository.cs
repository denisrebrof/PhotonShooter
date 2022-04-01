using System;
using Respawn.domain.model;

namespace Respawn.domain.repositories
{
    public interface ICurrentPlayerSpawnEventRepository
    {
        internal void AddSpawnEvent(SpawnEvent spawnEvent);
        public IObservable<SpawnEvent> GetSpawnEventFlow();
    }
}