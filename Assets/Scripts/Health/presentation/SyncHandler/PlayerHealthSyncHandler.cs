using Health.domain.repositories;
using Zenject;

namespace Health.presentation.SyncHandler
{
    public class PlayerHealthSyncHandler : HealthSyncHandler
    {
        [Inject] private ICurrentPlayerHealthRepository currentPlayerHealthRepository;
        protected override string HandlerId => photonView.Controller.UserId;
        protected override int CurrentHealth => currentPlayerHealthRepository.GetHealth();
    }
}