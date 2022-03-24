using Health.domain.repositories;
using Zenject;

namespace Health.presentation.HealthHandler
{
    public class PlayerHealthHandlerSyncAdapter: HealthHandlerSyncBase.IHealthHandlerSyncAdapter
    {
        [Inject] private IMaxHealthRepository maxHealthRepository;
        [Inject] private ICurrentPlayerHealthRepository currentPlayerHealthRepository;

        public int InitialHealth => maxHealthRepository.GetMaxHealth();
        public int CurrentHealth => currentPlayerHealthRepository.GetHealth();
    }
}