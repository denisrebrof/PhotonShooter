using System.Collections.Generic;
using System.Linq;
using Respawn.domain.model;
using Respawn.domain.repositories;

namespace Respawn.data
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