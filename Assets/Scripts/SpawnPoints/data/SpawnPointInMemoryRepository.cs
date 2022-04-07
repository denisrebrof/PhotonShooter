using System.Collections.Generic;
using System.Linq;
using Spawn.domain.model;
using SpawnPoints.domain.repositories;

namespace SpawnPoints.data
{
    public class SpawnPointInMemoryRepository : ISpawnPointRepository
    {
        private const int DEFAULT_COOLDOWN = 60;
        private readonly Dictionary<int, SpawnPoint> points = new();

        public SpawnPoint GetSpawnPoint(int pointId) => points.TryGetValue(pointId, out var point)
            ? point
            : new SpawnPoint(pointId, DEFAULT_COOLDOWN);

        public List<SpawnPoint> GetSpawnPoints() => points.Values.ToList();

        void ISpawnPointRepository.AddSpawnPoint(SpawnPoint point) => points[point.PointId] = point;
    }
}