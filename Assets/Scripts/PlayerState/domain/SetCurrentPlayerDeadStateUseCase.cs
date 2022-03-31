using MatchState.domain;
using MatchState.domain.model;
using MatchState.domain.repositories;
using Zenject;

namespace PlayerState.domain
{
    public class SetCurrentPlayerDeadStateUseCase
    {
        [Inject] private IMatchStateRepository matchStateRepository;

        public void SetDead()
        {
            if(matchStateRepository.GetMatchState() != MatchStates.Playing) return;
        }
    }
}