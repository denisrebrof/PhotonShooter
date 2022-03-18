using MatchState.domain.model;
using UniRx;
using Zenject;

namespace MatchState.domain
{
    public class SetMatchStateUseCase
    {
        [Inject] private MatchStateDurationUseCase matchStateDurationUseCase;
        [Inject] private IMatchStateRepository matchStateRepository;
        [Inject] private IMatchTimerRepository matchTimerRepository;

        public void SetMatchState(MatchStates state)
        {
            var currentState = matchStateRepository.GetMatchState();
            if(currentState == state) return;
            
            matchStateRepository.SetMatchState(state);
            matchTimerRepository.StopTimer();
            if (!matchStateDurationUseCase.GetStateDurationIfItHas(state, out var duration)) ;
            matchTimerRepository.StartTimer(duration);
        }
    }
}