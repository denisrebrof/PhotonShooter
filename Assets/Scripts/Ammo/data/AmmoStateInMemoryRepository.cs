using System;
using Ammo.domain;
using Ammo.domain.model;
using UniRx;

namespace Ammo.data
{
    public class AmmoStateInMemoryRepository : IAmmoStateRepository
    {
        private readonly BehaviorSubject<AmmoState> ammoStateSubject = new(AmmoState.Empty);

        public AmmoState GetAmmoState() => ammoStateSubject.Value;
        public IObservable<AmmoState> GetAmmoStateFlow() => ammoStateSubject;
        public void SetAmmoState(AmmoState state) => ammoStateSubject.OnNext(state);
    }
}