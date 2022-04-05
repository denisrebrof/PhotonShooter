using System;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace PlayerState.presentation
{
    public class AutoReadyAfterDeathHandler : MonoBehaviour
    {
        [SerializeField] private float readyDelay = 1f;
        [Inject] private ICurrentPlayerLifecycleEventRepository lifecycleEventRepository;
        [Inject] private ICurrentPlayerStateRepository currentPlayerStateRepository;

        private void Awake() => currentPlayerStateRepository
            .GetPlayerStateFlow()
            .Select(GetBecomeReadyDelay)
            .Switch()
            .Subscribe(_ =>
                lifecycleEventRepository.SendLifecycleEvent(PlayerLifecycleEvent.ReadyToSpawn)
            ).AddTo(this);

        private IObservable<Unit> GetBecomeReadyDelay(PlayerStates state) => state == PlayerStates.Dead
            ? Observable.Timer(TimeSpan.FromSeconds(1)).AsUnitObservable()
            : Observable.Empty<Unit>();
    }
}