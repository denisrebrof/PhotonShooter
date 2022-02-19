using System;
using Photon.Player.PlayerState.domain;
using UniRx;

namespace Photon.Player.PlayerState.data
{
    public class PlayerStateInMemoryRepository : IPlayerStateRepository
    {
        private readonly ReactiveProperty<domain.PlayerState> stateProperty = new(domain.PlayerState.None);

        public IObservable<domain.PlayerState> GetPlayerState() => stateProperty;

        public void SetPlayerState(domain.PlayerState state) => stateProperty.Value = state;
    }
}