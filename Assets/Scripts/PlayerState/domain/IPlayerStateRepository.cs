using System;

namespace PlayerState.domain
{
    public interface IPlayerStateRepository
    {
        IObservable<PlayerStates> GetPlayerState();
        void SetPlayerState(PlayerStates state);
    }
}