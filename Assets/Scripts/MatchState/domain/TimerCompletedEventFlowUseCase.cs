using System;
using UniRx;
using Zenject;

namespace MatchState.domain
{
    public class TimerCompletedEventFlowUseCase
    {
        [Inject] private IMatchTimerRepository matchTimerRepository;

        public IObservable<Unit> GetTimerCompletedEventFlow() => matchTimerRepository
            .GetMatchTimeSecondsFlow()
            .Scan((prev, next) => (prev > 0 && next <= 0) ? 1 : 0)
            .Where(res => res == 1)
            .AsUnitObservable();
    }
}