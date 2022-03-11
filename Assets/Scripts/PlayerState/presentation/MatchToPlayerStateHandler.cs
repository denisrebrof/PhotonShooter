using System;
using MatchState.domain;
using MatchState.domain.model;
using PlayerState.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace PlayerState.presentation
{
    public class MatchToPlayerStateHandler : MonoBehaviour
    {
        [Inject] private IMatchStateRepository matchStateRepository;
        [Inject] private IPlayerStateRepository playerStateRepository;

        private void Start() => matchStateRepository
            .GetMatchStateFlow()
            .DistinctUntilChanged()
            .Subscribe(HandleMatchState)
            .AddTo(this);

        private void HandleMatchState(MatchStates state)
        {
            if (state == MatchStates.Finished)
                playerStateRepository.SetPlayerState(PlayerStates.Idle);
            
            if (state == MatchStates.Playing)
                playerStateRepository.SetPlayerState(PlayerStates.Spawning);
        }
    }
}