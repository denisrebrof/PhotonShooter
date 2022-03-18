using System;
using MatchState.domain.model;
using UniRx;
using Zenject;

namespace MatchState.domain
{
    public class GetTimerStatePerMatchStateFlowUseCase
    {
        [Inject] private IMatchStateRepository matchStateRepository;
        [Inject] private IMatchTimerRepository matchTimerRepository;

        public IObservable<TimerState> GetTimerStateFlow(MatchStates state)
        {
            var timerSecondsFlow = matchTimerRepository.GetMatchTimeSecondsFlow();
            return matchStateRepository
                .GetMatchStateFlow()
                .Select(currentState => currentState == state)
                .WithLatestFrom(timerSecondsFlow, CreateTimerState)
                .DistinctUntilChanged();
        }

        private static TimerState CreateTimerState(bool isCorrectState, int timeLeft)
        {
            var time = isCorrectState ? timeLeft : 0;
            return new TimerState(false, time);
        }

        public struct TimerState
        {
            public bool IsActive;
            public int TimeLeft;

            public TimerState(bool isActive, int timeLeft)
            {
                this.IsActive = isActive;
                this.TimeLeft = timeLeft;
            }
        }
    }
}