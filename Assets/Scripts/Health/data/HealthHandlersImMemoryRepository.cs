using System;
using Health.domain.repositories;
using UniRx;
using Utils;

namespace Health.data
{
    public class HealthHandlersImMemoryRepository : IHealthHandlersRepository
    {
        private readonly ReactiveDictionary<string, int> handlerIdToHealthMap = new();

        public int GetHealth(string handlerId) => handlerIdToHealthMap[handlerId];

        public void SetHealth(string handlerId, int health) => handlerIdToHealthMap[handlerId] = health;

        public IObservable<int> GetHealthFlow(string handlerId) => handlerIdToHealthMap
            .GetItemFlow(handlerId)
            .DistinctUntilChanged();
    }
}