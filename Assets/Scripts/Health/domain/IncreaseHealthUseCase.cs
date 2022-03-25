using System;
using Health.domain.model;
using Health.domain.repositories;
using Zenject;

namespace Health.domain
{
    public class IncreaseHealthUseCase
    {
        [Inject] private ICurrentPlayerHealthRepository currentPlayerHealthRepository;
        [Inject] private IMaxHealthRepository maxHealthRepository;
        
        public IncreaseHealthResult IncreaseHealth(int amount)
        {
            var currentHealth = currentPlayerHealthRepository.GetHealth();
            var maxHealth = maxHealthRepository.GetMaxHealth();
            if (currentHealth >= maxHealth)
                return IncreaseHealthResult.AlreadyFull;

            currentHealth = Math.Min(maxHealth, currentHealth + amount);
            currentPlayerHealthRepository.SetHealth(currentHealth);
            return currentHealth < maxHealth ? IncreaseHealthResult.Increased : IncreaseHealthResult.HealthFilledUp;
        }
    }
}