using System;
using MatchState.domain.model;

namespace MatchState.domain.repositories
{
    public interface IMatchStateRepository
    {
        internal void SetMatchState(MatchStates state);
        public IObservable<MatchStates> GetMatchStateFlow();
        MatchStates GetMatchState();
    }
}