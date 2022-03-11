using System;
using PlayerState.domain;
using UniRx;

namespace PlayerState.data
{
    public class PlayerStateInMemoryRepository : IPlayerStateRepository
    {
        private readonly ReactiveProperty<PlayerStates> stateProperty = new(PlayerStates.None);

        public IObservable<PlayerStates> GetPlayerState() => stateProperty;

        public void SetPlayerState(PlayerStates states) => stateProperty.Value = states;
    }
}