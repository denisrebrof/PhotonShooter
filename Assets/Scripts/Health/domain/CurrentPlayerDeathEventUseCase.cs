using System;
using Health.domain.repositories;
using UniRx;
using Zenject;

namespace Health.domain
{
    public class CurrentPlayerDeathEventUseCase
    {
        [Inject] private ICurrentPlayerHealthRepository repository;

        public IObservable<Unit> GetDeathEventFlow() => repository
            .GetHealthFlow()
            .DistinctUntilChanged()
            .Where(health => health == 0)
            .AsUnitObservable();
    }
}