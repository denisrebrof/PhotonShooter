using System;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;
using Zenject;

namespace Respawn.domain
{
    public class SpawnCurrentPlayerAvailableUseCase
    {
        [Inject] private ICurrentPlayerStateRepository currentPlayerStateRepository;

        public IObservable<bool> GetSpawnAvailableFlow() => currentPlayerStateRepository
            .GetPlayerStateFlow()
            .Select(state => state == PlayerStates.Spawning)
            .DistinctUntilChanged();

        public bool GetSpawnAvailable() => currentPlayerStateRepository.GetPlayerState() == PlayerStates.Spawning;
    }
}