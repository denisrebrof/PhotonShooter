using System;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;
using Zenject;

namespace Spawn.domain
{
    public class SpawnPlayerAvailableUseCase
    {
        [Inject] private IPlayerStateRepository playerStateRepository;

        public IObservable<bool> GetSpawnAvailableFlow() => playerStateRepository
            .GetPlayerStateFlow()
            .Select(state => state == PlayerStates.Spawning)
            .DistinctUntilChanged();

        public bool GetSpawnAvailable() => playerStateRepository.GetPlayerState() == PlayerStates.Spawning;
    }
}