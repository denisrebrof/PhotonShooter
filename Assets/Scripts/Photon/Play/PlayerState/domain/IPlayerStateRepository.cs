using System;

namespace Photon.Play.PlayerState.domain
{
    public interface IPlayerStateRepository
    {
        IObservable<PlayerState> GetPlayerState();
        void SetPlayerState(PlayerState state);
    }
}