using System;
using MatchState.domain.model;
using UnityEngine;

namespace MatchState.domain
{
    public interface IMatchStateRepository
    {
        public void SetMatchState(MatchStates state);
        public IObservable<MatchStates> GetMatchStateFlow();
    }
}