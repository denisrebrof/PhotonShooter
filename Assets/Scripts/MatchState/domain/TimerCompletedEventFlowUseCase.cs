using System;
using MatchState.domain.repositories;
using UniRx;
using UnityEngine;
using Utils;
using Zenject;

namespace MatchState.domain
{
    public class TimerCompletedEventFlowUseCase
    {
        [Inject] private IMatchTimerRepository matchTimerRepository;

        public IObservable<Unit> GetTimerCompletedEventFlow() => matchTimerRepository
            .GetMatchTimeSecondsFlow()
            .CombineWithPrevious((prev, next) => prev > 0 && next <= 0)
            .Where(res => res)
            .AsUnitObservable();
    }
}