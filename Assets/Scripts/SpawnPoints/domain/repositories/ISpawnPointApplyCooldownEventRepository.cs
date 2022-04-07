using System;
using SpawnPoints.domain.model;

namespace SpawnPoints.domain.repositories
{
    public interface ISpawnPointApplyCooldownEventRepository
    {
        internal void AddApplyCooldownEvent(int pointId, int cooldown);
        public IObservable<ApplyCooldownEvent> GetApplyCooldownEventFlow();
    }
}