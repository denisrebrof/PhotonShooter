using System.Collections.Generic;
using Spawn.domain.model;

namespace SpawnPoints.domain.repositories
{
    public interface ISpawnPointRepository
    {
        public SpawnPoint GetSpawnPoint(int pointId);
        public List<SpawnPoint> GetSpawnPoints();
        internal void AddSpawnPoint(SpawnPoint point);
    }
}