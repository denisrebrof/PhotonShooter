using System;
using Ammo.domain;
using UniRx;

namespace Ammo.data
{
    public class LoadedAmmoInMemoryRepository: IAmmoRepository
    {
        private readonly BehaviorSubject<int> ammoSubject = new(0);

        public int GetLoadedAmmoCount() => ammoSubject.Value;

        public IObservable<int> GetLoadedAmmoCountFlow() => ammoSubject;

        public void SetLoadedAmmo(int count) => ammoSubject.OnNext(count);
    }
}