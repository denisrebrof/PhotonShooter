using System;
using JetBrains.Annotations;
using MatchState.domain;
using UniRx;

namespace MatchState.data
{
    public class MatchTimerInMemoryRepository : IMatchTimerRepository
    {
        [CanBeNull] private IDisposable timerSubscription;
        private readonly BehaviorSubject<int> currentTimer = new(0);

        public IObservable<int> GetMatchTimeSecondsFlow() => currentTimer;

        public void StartTimer(int seconds)
        {
            timerSubscription?.Dispose();
            if (seconds < 0) return;
            currentTimer.OnNext(seconds);
            timerSubscription = Observable
                .Timer(TimeSpan.FromSeconds(1))
                .Repeat()
                .Where(_ => currentTimer.Value > 0)
                .Subscribe(_ =>
                    currentTimer.OnNext(currentTimer.Value - 1)
                );
        }

        public void StopTimer()
        {
            timerSubscription?.Dispose();
        }

        ~MatchTimerInMemoryRepository()
        {
            timerSubscription?.Dispose();
        }
    }
}