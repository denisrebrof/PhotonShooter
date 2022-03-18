using System;
using MatchState.domain.model;
using UniRx;
using Zenject;

namespace MatchState.domain
{
    public class GetMatchStateTimerUpdateRequestsFlowUseCase
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