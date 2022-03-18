using MatchState.domain.model;
using UniRx;
using Zenject;

namespace MatchState.domain
{
    public class StartMatchStateUseCase
    {
        [Inject] private MatchStateDurationUseCase matchStateDurationUseCase;
        [Inject] private IMatchStateRepository matchStateRepository;
        [Inject] private IMatchTimerRepository matchTimerRepository;

        public void StartMatchState(MatchStates state)
        {
            var currentState = matchStateRepository.GetMatchState();
            if(currentState == state) return;
            
            matchStateRepository.SetMatchState(state);
            matchTimerRepository.StopTimer();
            if (!matchStateDurationUseCase.GetStateDurationIfItHas(state, out var duration)) return;
            matchTimerRepository.StartTimer(duration);
        }
    }
}