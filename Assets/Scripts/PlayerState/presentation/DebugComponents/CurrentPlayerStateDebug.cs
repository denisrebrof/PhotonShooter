using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace PlayerState.presentation.DebugComponents
{
    public class CurrentPlayerStateDebug : MonoBehaviour
    {
        [Inject] private ICurrentPlayerStateRepository playerStateRepository;

        private void Awake() => playerStateRepository
            .GetPlayerStateFlow()
            .Subscribe(LogPlayerState)
            .AddTo(this);

        private static void LogPlayerState(PlayerStates state) => Debug.Log($"New Player State: {state}");
    }
}