using System;

namespace Respawn.domain.repositories
{
    public interface ISpawnPointCooldownRepository
    {
        public IObservable<int> GetCooldownFlow(int pointId);
        public int GetCooldown(int pointId);
        internal void SetCooldown(int pointId, int cooldown);
    }
}