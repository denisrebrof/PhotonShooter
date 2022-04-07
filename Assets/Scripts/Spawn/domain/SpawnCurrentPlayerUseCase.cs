using PlayerState.domain.model;
using PlayerState.domain.repositories;
using Spawn.domain.model;
using Spawn.domain.repositories;
using Zenject;

namespace Spawn.domain
{
    public class SpawnCurrentPlayerUseCase
    {
        // [Inject] private SpawnPlayerAvailableUseCase spawnPlayerAvailableUseCase;
        // [Inject] private SpawnPointAvailableUseCase spawnPointAvailableUseCase;
        // [Inject] private ISpawnPointRepository spawnPointRepository;
        // [Inject] private ICurrentPlayerSpawnEventRepository spawnEventRepository;
        // [Inject] private IPlayerLifecycleEventRepository lifecycleEventRepository;
        // [Inject] private ISpawnPointCooldownRepository spawnPointCooldownRepository;
        //
        // public SpawnResult Spawn(int pointId)
        // {
        //     if (!spawnPlayerAvailableUseCase.GetSpawnAvailable())
        //         return SpawnResult.CouldNotSpawn;
        //     
        //     if (!spawnPointAvailableUseCase.GetSpawnAvailable(pointId))
        //         return SpawnResult.SpawnNotAvailable;
        //
        //     var point = spawnPointRepository.GetSpawnPoint(pointId);
        //     spawnEventRepository.AddSpawnEvent(SpawnEvent.FromPointDefault(point));
        //     lifecycleEventRepository.SendLifecycleEvent(PlayerLifecycleEvent.Spawned);
        //     spawnPointCooldownRepository.SetCooldown(point.PointId, point.DefaultCooldown);
        //     return SpawnResult.Success;
        // }

        public enum SpawnResult
        {
            CouldNotSpawn,
            SpawnNotAvailable,
            Success
        }
    }
}