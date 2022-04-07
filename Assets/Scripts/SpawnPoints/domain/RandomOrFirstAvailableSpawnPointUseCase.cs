using System;
using System.Collections.Generic;
using System.Linq;
using SpawnPoints.domain.repositories;
using UniRx;
using Zenject;
using Random = UnityEngine.Random;

namespace SpawnPoints.domain
{
    public class RandomOrFirstAvailableSpawnPointUseCase
    {
        [Inject] private SpawnPointAvailableUseCase spawnPointAvailableUseCase;
        [Inject] private ISpawnPointRepository spawnPointRepository;

        public IObservable<int> GetSpawnPointId()
        {
            var pointIds = spawnPointRepository.GetSpawnPoints().Select(point => point.PointId).ToList();
            var availablePoints = pointIds.Where(spawnPointAvailableUseCase.GetSpawnAvailable).ToList();

            if (!availablePoints.Any())
                return GetFirstAvailableSpawnPoint(pointIds);

            var point = availablePoints[Random.Range(0, availablePoints.Count)];
            return Observable.Return(point);
        }

        private IObservable<int> GetFirstAvailableSpawnPoint(List<int> pointIds) => pointIds.Select(pointId =>
            spawnPointAvailableUseCase
                .GetSpawnAvailableFlow(pointId)
                .Where(available => available)
                .Select(_ => pointId)
        ).Merge().Take(1);
    }
}