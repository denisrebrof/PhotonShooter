using System;
using Photon.Play.PlayerState.domain;
using UniRx;

namespace Photon.Play.PlayerState.data
{
    public class PlayerStateInMemoryRepository : IPlayerStateRepository
    {
        private readonly ReactiveProperty<domain.PlayerState> stateProperty = new(domain.PlayerState.None);

        public IObservable<domain.PlayerState> GetPlayerState() => stateProperty;

        public void SetPlayerState(domain.PlayerState state) => stateProperty.Value = state;
    }
}