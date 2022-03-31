using System;
using MatchState.domain.model;
using MatchState.domain.repositories;
using UniRx;
using Zenject;

namespace MatchState.domain
{
    internal class GetMatchStateTimerUpdatesUseCase
    {
        [Inject] private TimerCompletedEventFlowUseCase timerCompletedEventFlowUseCase;
        [Inject] private IMatchStateRepository stateRepository;
        [Inject] private GetNextMatchStateUseCase getNextMatchStateUseCase;

        public IObservable<MatchStates> GetMatchStateTimerUpdateRequestsFlow() => timerCompletedEventFlowUseCase
            .GetTimerCompletedEventFlow()
            .Select(_ => GetNextMatchState());

        private MatchStates GetNextMatchState()
        {
            var currentState = stateRepository.GetMatchState();
            return getNextMatchStateUseCase.GetNextMatchState(currentState);
        }
    }
}