using PlayerState.domain;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using Respawn.domain.model;
using Respawn.domain.repositories;
using Zenject;

namespace Respawn.domain
{
    public class SpawnCurrentPlayerUseCase
    {
        [Inject] private SpawnCurrentPlayerAvailableUseCase spawnCurrentPlayerAvailableUseCase;
        [Inject] private SpawnPointAvailableUseCase spawnPointAvailableUseCase;
        [Inject] private ISpawnPointRepository spawnPointRepository;
        [Inject] private ICurrentPlayerSpawnEventRepository spawnEventRepository;
        [Inject] private ICurrentPlayerLifecycleEventRepository lifecycleEventRepository;
        [Inject] private ISpawnPointCooldownRepository spawnPointCooldownRepository;

        public SpawnResult Spawn(int pointId)
        {
            if (!spawnCurrentPlayerAvailableUseCase.GetSpawnAvailable())
                return SpawnResult.CouldNotSpawn;
            
            if (!spawnPointAvailableUseCase.GetSpawnAvailable(pointId))
                return SpawnResult.SpawnNotAvailable;

            var point = spawnPointRepository.GetSpawnPoint(pointId);
            spawnEventRepository.AddSpawnEvent(SpawnEvent.FromPointDefault(point));
            lifecycleEventRepository.SendLifecycleEvent(PlayerLifecycleEvent.Spawned);
            spawnPointCooldownRepository.SetCooldown(point.PointId, point.DefaultCooldown);
            return SpawnResult.Success;
        }

        public enum SpawnResult
        {
            CouldNotSpawn,
            SpawnNotAvailable,
            Success
        }
    }
}