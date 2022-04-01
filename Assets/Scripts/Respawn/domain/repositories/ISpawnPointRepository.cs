using System.Collections.Generic;
using Respawn.domain.model;

namespace Respawn.domain.repositories
{
    public interface ISpawnPointRepository
    {
        public SpawnPoint GetSpawnPoint(int pointId);
        public List<SpawnPoint> GetSpawnPoints();
        internal void AddSpawnPoint(SpawnPoint point);
    }
}