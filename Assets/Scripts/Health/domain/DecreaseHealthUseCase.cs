using System;
using Health.domain.model;
using UnityEngine;
using Zenject;

namespace Health.domain
{
    public class DecreaseHealthUseCase
    {
        [Inject] private IHealthRepository healthRepository;
        public DecreaseHealthResult DecreaseHealth(int amount)
        {
            var currentHealth = healthRepository.GetHealth(); 
            if (currentHealth <= 0)
                return DecreaseHealthResult.NoHealth;

            currentHealth = Math.Max(0, currentHealth - amount);
            healthRepository.SetHealth(currentHealth);
            return currentHealth > 0 ? DecreaseHealthResult.Decreased : DecreaseHealthResult.HealthRanOut;
        }
    }
}