using System;
using MatchState.domain.model;
using MatchState.domain.repositories;
using Respawn.domain;
using Respawn.domain.repositories;
using UniRx;
using Zenject;

namespace Respawn.presentation
{
    public class SpawnInitialCooldownNavigator
    {
        [Inject] private IMatchStateRepository matchStateRepository;
        [Inject] private ISpawnPointCooldownRepository spawnPointCooldownRepository;

        public IDisposable CreateInitialCooldownHandler(int pointId, int initialCooldown) => matchStateRepository
            .GetMatchStateFlow()
            .DistinctUntilChanged()
            .Where(state => state == MatchStates.Playing)
            .AsUnitObservable()
            .Subscribe(_ => { spawnPointCooldownRepository.SetCooldown(pointId, initialCooldown); });
    }
}