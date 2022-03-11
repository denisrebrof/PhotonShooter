using System;
using Health.domain.model;
using Zenject;

namespace Health.domain
{
    public class IncreaseHealthUseCase
    {
        [Inject] private IHealthRepository healthRepository;
        [Inject] private IMaxHealthRepository maxHealthRepository;
        
        public IncreaseHealthResult IncreaseHealth(int amount)
        {
            var currentHealth = healthRepository.GetHealth();
            var maxHealth = maxHealthRepository.GetMaxHealth();
            if (currentHealth >= maxHealth)
                return IncreaseHealthResult.AlreadyFull;

            currentHealth = Math.Min(maxHealth, currentHealth + amount);
            healthRepository.SetHealth(currentHealth);
            return currentHealth < maxHealth ? IncreaseHealthResult.Increased : IncreaseHealthResult.HealthFilledUp;
        }
    }
}