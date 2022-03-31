using System;
using MatchState.domain.model;
using MatchState.domain.repositories;
using UniRx;

namespace MatchState.data
{
    internal class MatchStateInMemoryRepository : IMatchStateRepository
    {
        private readonly BehaviorSubject<MatchStates> matchStateSubject = new(MatchStates.None);
        
        void IMatchStateRepository.SetMatchState(MatchStates state)
        {
            if (matchStateSubject.Value == state) return;
            matchStateSubject.OnNext(state);
        }

        public IObservable<MatchStates> GetMatchStateFlow() => matchStateSubject;
        public MatchStates GetMatchState() => matchStateSubject.Value;
    }
}