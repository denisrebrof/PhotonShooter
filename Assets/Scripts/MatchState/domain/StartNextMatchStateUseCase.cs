using MatchState.domain.repositories;
using Zenject;

namespace MatchState.domain
{
    public class StartNextMatchStateUseCase
    {
        [Inject] private StartMatchStateUseCase startMatchStateUseCase;
        [Inject] private NextMatchStateUseCase getNextMatchStateUseCase;
        [Inject] private IMatchStateRepository matchStateRepository;

        public void StartNextMatchState()
        {
            var currentState = matchStateRepository.GetMatchState();
            var nextState = getNextMatchStateUseCase.GetNextMatchState(currentState);
            startMatchStateUseCase.StartMatchState(nextState);
        }
    }
}