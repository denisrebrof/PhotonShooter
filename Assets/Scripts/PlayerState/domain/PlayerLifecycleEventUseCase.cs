using PlayerState.domain.model;
using PlayerState.domain.repositories;
using Zenject;

namespace PlayerState.domain
{
    public class PlayerLifecycleEventUseCase
    {
        [Inject] private ICurrentPlayerLifecycleEventRepository lifecycleEventRepository;
        
        public void Send(PlayerLifecycleEvent lifecycleEvent) => lifecycleEventRepository.SendLifecycleEvent(lifecycleEvent);
    }
}