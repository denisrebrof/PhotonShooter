using System;
using PlayerState.domain.model;

namespace PlayerState.domain.repositories
{
    public interface IPlayerLifecycleEventRepository
    {
        public IObservable<PlayerLifecycleEvent> GetLifecycleEvents();
        public void SendLifecycleEvent(PlayerLifecycleEvent lifecycleEvent);
    }
}