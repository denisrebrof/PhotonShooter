using System;
using PlayerState.domain.model;

namespace PlayerState.domain.repositories
{
    internal interface ICurrentPlayerLifecycleEventRepository
    {
        public IObservable<PlayerLifecycleEvent> GetLifecycleEvents();
        public void SendLifecycleEvent(PlayerLifecycleEvent lifecycleEvent);
    }
}