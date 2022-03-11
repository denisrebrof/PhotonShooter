using Zenject;

namespace Health.domain
{
    public class RestoreHealthUseCase
    {
        [Inject] private IHealthRepository healthRepository;
        [Inject] private IMaxHealthRepository maxHealthRepository;

        public void RestoreHealth()
        {
            var maxHealth = maxHealthRepository.GetMaxHealth();
            healthRepository.SetHealth(maxHealth);
        }
    }
}