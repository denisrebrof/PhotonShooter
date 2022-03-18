using System;
using MatchState.domain;
using MatchState.domain.model;
using UniRx;

namespace MatchState.data
{
    public class MatchStateInMemoryRepository : IMatchStateRepository
    {
        private readonly BehaviorSubject<MatchStates> matchStateSubject = new(MatchStates.None);

        public void SetMatchState(MatchStates state)
        {
            if (matchStateSubject.Value == state) return;
            matchStateSubject.OnNext(state);
        }

        public IObservable<MatchStates> GetMatchStateFlow() => matchStateSubject;
        public MatchStates GetMatchState() => matchStateSubject.Value;
    }
}