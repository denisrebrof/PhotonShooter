using System;
using SpawnPoints.domain.model;
using SpawnPoints.domain.repositories;
using UniRx;

namespace SpawnPoints.data
{
    public class SpawnPointApplyCooldownEventInMemoryRepository: ISpawnPointApplyCooldownEventRepository
    {
        private readonly Subject<ApplyCooldownEvent> eventsSubject = new();

        void ISpawnPointApplyCooldownEventRepository.AddApplyCooldownEvent(int pointId, int cooldown)
        {
            eventsSubject.OnNext(new ApplyCooldownEvent(pointId, cooldown));
        }

        public IObservable<ApplyCooldownEvent> GetApplyCooldownEventFlow() => eventsSubject;
    }
}