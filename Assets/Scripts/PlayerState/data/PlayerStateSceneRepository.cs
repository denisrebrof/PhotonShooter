using System;
using PlayerState.domain;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace PlayerState.data
{
    internal class PlayerStateSceneRepository : MonoBehaviour, IPlayerStateRepository
    {
        [Inject] private PlayerStateUpdatesUseCase updatesUseCase;

        private readonly ReactiveProperty<PlayerStates> stateProperty = new(PlayerStates.None);

        private void Awake() => updatesUseCase
            .GetPlayerStateUpdatesFlow()
            .Subscribe(SetPlayerState)
            .AddTo(this);

        public IObservable<PlayerStates> GetPlayerStateFlow() => stateProperty;

        public PlayerStates GetPlayerState() => stateProperty.Value;

        void SetPlayerState(PlayerStates states) => stateProperty.Value = states;
    }
}