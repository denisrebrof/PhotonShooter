using System;
using Health.domain.repositories;
using UniRx;
using Zenject;

namespace Health.domain
{
    public class CurrentPlayerDeathEventUseCase
    {
        [Inject] private ICurrentPlayerHealthRepository repository;

        public ReactiveCommand GetDeathEventFlow() => repository
            .GetHealthFlow()
            .DistinctUntilChanged()
            .Select(health => health == 0)
            .ToReactiveCommand();
    }
}