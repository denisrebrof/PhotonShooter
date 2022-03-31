using System;
using PlayerState.domain.model;

namespace PlayerState.domain.repositories
{
    public interface ICurrentPlayerStateRepository
    {
        public IObservable<PlayerStates> GetPlayerStateFlow();
        public PlayerStates GetPlayerState();
        internal void SetCurrentPlayerState(PlayerStates states);
    }
}