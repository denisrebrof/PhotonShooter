﻿using System;
using JetBrains.Annotations;
using MatchState.domain;
using MatchState.domain.repositories;
using UniRx;

namespace MatchState.data
{
    public class MatchTimerInMemoryRepository : IMatchTimerRepository
    {
        [CanBeNull] private IDisposable timerSubscription;
        private readonly BehaviorSubject<int> currentTimer = new(0);

        public IObservable<int> GetMatchTimeSecondsFlow() => currentTimer;

        void IMatchTimerRepository.StartTimer(int seconds)
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

        void IMatchTimerRepository.StopTimer() => DisposeTimer();

        private void DisposeTimer()
        {
            timerSubscription?.Dispose();
            timerSubscription = null;
        }

        ~MatchTimerInMemoryRepository() => DisposeTimer();
    }
}