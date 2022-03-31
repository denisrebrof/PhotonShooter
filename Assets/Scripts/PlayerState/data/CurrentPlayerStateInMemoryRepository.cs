using System;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;

namespace PlayerState.data
{
    internal class CurrentPlayerStateInMemoryRepository : ICurrentPlayerStateRepository
    {
        private readonly ReactiveProperty<PlayerStates> stateProperty = new(PlayerStates.None);

        public IObservable<PlayerStates> GetPlayerStateFlow() => stateProperty;

        public PlayerStates GetPlayerState() => stateProperty.Value;

        void ICurrentPlayerStateRepository.SetCurrentPlayerState(PlayerStates states) => stateProperty.Value = states;
    }
}