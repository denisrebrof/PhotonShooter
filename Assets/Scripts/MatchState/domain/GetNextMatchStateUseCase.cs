using MatchState.domain.model;

namespace MatchState.domain
{
    public class GetNextMatchStateUseCase
    {
        public MatchStates GetNextMatchState(MatchStates current) => current switch
        {
            MatchStates.Playing => MatchStates.Finished,
            _ => MatchStates.Playing
        };
    }
}