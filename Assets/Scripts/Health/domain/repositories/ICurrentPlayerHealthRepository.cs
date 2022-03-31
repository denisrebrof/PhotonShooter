using System;

namespace Health.domain.repositories
{
    public interface ICurrentPlayerHealthRepository
    {
        internal void SetHealth(int health);
        public int GetHealth();
        public IObservable<int> GetHealthFlow();
    }
}