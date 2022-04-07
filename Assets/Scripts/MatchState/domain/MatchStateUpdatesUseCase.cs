using System;
using MatchState.domain.model;
using MatchState.domain.repositories;
using MatchTimer.domain;
using UniRx;
using Zenject;

namespace MatchState.domain
{
    internal class MatchStateUpdatesUseCase
    {
        [Inject] private TimerCompletedEventUseCase timerCompletedEventUseCase;
        [Inject] private IMatchStateRepository stateRepository;
        [Inject] private NextMatchStateUseCase nextMatchStateUseCase;

        public IObservable<MatchStates> GetUpdatesFlow() => timerCompletedEventUseCase
            .GetTimerCompletedEventFlow()
            .Select(_ => GetNextMatchState());

        private MatchStates GetNextMatchState()
        {
            var currentState = stateRepository.GetMatchState();
            return nextMatchStateUseCase.GetNextMatchState(currentState);
        }
    }
}