using Health.domain.repositories;
using Zenject;

namespace Health.domain
{
    public class RestoreHealthUseCase
    {
        [Inject] private ICurrentPlayerHealthRepository currentPlayerHealthRepository;
        [Inject] private IMaxHealthRepository maxHealthRepository;

        public void RestoreHealth()
        {
            var maxHealth = maxHealthRepository.GetMaxHealth();
            currentPlayerHealthRepository.SetHealth(maxHealth);
        }
    }
}