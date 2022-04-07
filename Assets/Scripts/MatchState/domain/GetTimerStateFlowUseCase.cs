using System;
using MatchState.domain.model;
using MatchState.domain.repositories;
using MatchTimer.domain.repositories;
using UniRx;
using Zenject;

namespace MatchState.domain
{
    public class GetTimerStateFlowUseCase
    {
        [Inject] private IMatchStateRepository matchStateRepository;
        [Inject] private IMatchTimerRepository matchTimerRepository;

        public IObservable<TimerState> GetTimerStateFlow(MatchStates state)
        {
            var correctMatchStateFlow = matchStateRepository
                .GetMatchStateFlow()
                .Select(currentState => currentState == state);
            return matchTimerRepository.GetMatchTimeSecondsFlow()
                .WithLatestFrom(correctMatchStateFlow, CreateTimerState)
                .DistinctUntilChanged();
        }

        private static TimerState CreateTimerState(int timeLeft, bool isCorrectState)
        {
            var time = isCorrectState ? timeLeft : 0;
            return new TimerState(isCorrectState, time);
        }
    }
}