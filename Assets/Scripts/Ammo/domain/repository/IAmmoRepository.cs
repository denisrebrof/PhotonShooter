using System;

namespace Ammo.domain
{
    public interface IAmmoRepository
    {
        public int GetLoadedAmmoCount();
        public IObservable<int> GetLoadedAmmoCountFlow();
        public void SetLoadedAmmo(int count);
    }
}