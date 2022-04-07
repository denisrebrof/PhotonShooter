using PlayerState.domain.model;
using PlayerState.domain.repositories;
using Spawn.domain;
using UniRx;
using UnityEngine;
using Zenject;

namespace Spawn.presentation
{
    public class ReadyAfterDeathHandler : MonoBehaviour
    {
        [Inject] private ReadyAfterDeathCommandUseCase readyAfterDeathCommandUseCase;
        [Inject] private IPlayerLifecycleEventRepository lifecycleEventRepository;

        [SerializeField] private int readyDelay = 1;

        private void Awake() => readyAfterDeathCommandUseCase
            .GetReadyCommandFlow(readyDelay)
            .Subscribe(_ =>
                lifecycleEventRepository.SendLifecycleEvent(PlayerLifecycleEvent.Ready)
            ).AddTo(this);
    }
}