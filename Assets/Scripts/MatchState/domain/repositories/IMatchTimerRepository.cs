using System;

namespace MatchState.domain.repositories
{
    public interface IMatchTimerRepository
    {
        public IObservable<int> GetMatchTimeSecondsFlow();
        internal void StartTimer(int seconds);
        internal void StopTimer();
    }
}