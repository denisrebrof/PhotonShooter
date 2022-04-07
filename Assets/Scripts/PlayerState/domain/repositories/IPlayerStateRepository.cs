using System;
using PlayerState.domain.model;

namespace PlayerState.domain.repositories
{
    public interface IPlayerStateRepository
    {
        public IObservable<PlayerStates> GetPlayerStateFlow();
        public PlayerStates GetPlayerState();
    }
}