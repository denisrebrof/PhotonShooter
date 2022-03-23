using System;
using Health.domain.model;
using Health.domain.repositories;
using UnityEngine;
using Zenject;

namespace Health.domain
{
    public class DecreaseHealthUseCase
    {
        [Inject] private ICurrentPlayerHealthRepository currentPlayerHealthRepository;
        public DecreaseHealthResult DecreaseHealth(int amount)
        {
            var currentHealth = currentPlayerHealthRepository.GetHealth(); 
            if (currentHealth <= 0)
                return DecreaseHealthResult.NoHealth;

            currentHealth = Math.Max(0, currentHealth - amount);
            currentPlayerHealthRepository.SetHealth(currentHealth);
            return currentHealth > 0 ? DecreaseHealthResult.Decreased : DecreaseHealthResult.HealthRanOut;
        }
    }
}