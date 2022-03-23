using System;
using Health.domain;
using Health.domain.repositories;
using UniRx;
using Zenject;

namespace Health.data
{
    public class InMemoryHealthRepository: ICurrentPlayerHealthRepository
    {
         private readonly BehaviorSubject<int> healthSubject;

        [Inject]
        public InMemoryHealthRepository(IMaxHealthRepository maxHealthRepository)
        {
            var maxHealth = maxHealthRepository.GetMaxHealth();
            healthSubject = new BehaviorSubject<int>(maxHealth);
        }

        public void SetHealth(int health) => healthSubject.OnNext(health);

        public int GetHealth() => healthSubject.Value;

        public IObservable<int> GetHealthFlow() => healthSubject;
    }
}