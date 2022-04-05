using Health.domain;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;
using UnityEngine;
using Zenject;

namespace Health.presentation
{
    public class CurrentPlayerDeathEventHandler : MonoBehaviour
    {
        [Inject] private CurrentPlayerDeathEventUseCase deathEventUseCase;
        [Inject] private ICurrentPlayerLifecycleEventRepository lifecycleEventRepository;

        private void Awake() => deathEventUseCase
            .GetDeathEventFlow()
            .Subscribe(_ =>
                lifecycleEventRepository.SendLifecycleEvent(PlayerLifecycleEvent.Died)
            ).AddTo(this);
    }
}