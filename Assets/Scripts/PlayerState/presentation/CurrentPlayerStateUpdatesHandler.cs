using System;
using PlayerState.domain;
using PlayerState.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace PlayerState.presentation
{
    public class CurrentPlayerStateUpdatesHandler : MonoBehaviour
    {
        [Inject] private ICurrentPlayerStateRepository repository;
        [Inject] private CurrentPlayerStateUpdatesUseCase updatesUseCase;

        private void Awake() => updatesUseCase
            .GetPlayerStateUpdatesFlow()
            .Subscribe(repository.SetCurrentPlayerState)
            .AddTo(this);
    }
}