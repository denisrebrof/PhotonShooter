using System;

namespace MatchState.domain
{
    public interface IMatchTimerRepository
    {
        public IObservable<int> GetMatchTimeSecondsFlow();
        public void StartTimer(int seconds);
    }
}