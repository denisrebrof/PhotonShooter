using System;
using Health.domain.model;

namespace Health.domain
{
    public interface IHealthRepository
    {
        public void SetHealth(int health);
        public int GetHealth();
        public IObservable<int> GetHealthFlow();
    }
}