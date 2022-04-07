using MatchTimer.domain.repositories;
using UniRx;
using Utils.Reactive;
using Zenject;

namespace MatchTimer.domain
{
    public class TimerCompletedEventUseCase
    {
        [Inject] private IMatchTimerRepository matchTimerRepository;

        public ReactiveCommand GetTimerCompletedEventFlow() => matchTimerRepository
            .GetMatchTimeSecondsFlow()
            .CombineWithPrevious((prev, next) => prev > 0 && next <= 0)
            .Where(res => res)
            .ToReactiveCommand();
    }
}