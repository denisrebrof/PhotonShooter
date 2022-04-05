using Health.domain;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace Health.presentation
{
    public class RestoreHealthOnSpawnHandler : MonoBehaviour
    {
        [Inject] private ICurrentPlayerLifecycleEventRepository lifecycleEventRepository;
        [Inject] private RestoreHealthUseCase restoreHealthUseCase;

        private void Awake() => lifecycleEventRepository
            .GetLifecycleEvents()
            .Where(lifecycleEvent => lifecycleEvent == PlayerLifecycleEvent.Spawned)
            .Subscribe(_ => restoreHealthUseCase.RestoreHealth())
            .AddTo(this);
    }
}