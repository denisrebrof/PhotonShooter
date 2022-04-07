using System;
using PlayerState.domain.model;
using PlayerState.domain.repositories;
using UniRx;

namespace PlayerState.data
{
    internal class PlayerLifecycleEventInMemoryRepository: IPlayerLifecycleEventRepository
    {
        private readonly Subject<PlayerLifecycleEvent> eventSubject = new();
        public IObservable<PlayerLifecycleEvent> GetLifecycleEvents() => eventSubject;
        public void SendLifecycleEvent(PlayerLifecycleEvent lifecycleEvent) => eventSubject.OnNext(lifecycleEvent);
    }
}