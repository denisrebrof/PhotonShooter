using System;
using Health.domain.repositories;
using UniRx;
using Zenject;

namespace Health.domain
{
    public class RelativeHealthUseCase
    {
        [Inject] private IHealthHandlersRepository healthHandlersRepository;
        [Inject] private IMaxHealthRepository maxHealthRepository;

        public IObservable<float> GetRelativeHealthFlow(string handlerId)
        {
            var max = maxHealthRepository.GetMaxHealth();
            return healthHandlersRepository.GetHealthFlow(handlerId).Select(health => ((float) health) / max);
        }

        public float GetRelativeHealth(string handlerId)
        {
            var max = maxHealthRepository.GetMaxHealth();
            var health = healthHandlersRepository.GetHealth(handlerId);
            return ((float) health) / max;
        }
    }
}