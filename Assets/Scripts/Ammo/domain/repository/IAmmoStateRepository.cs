using System;
using Ammo.domain.model;

namespace Ammo.domain
{
    public interface IAmmoStateRepository
    {
        public AmmoState GetAmmoState();
        public IObservable<AmmoState> GetAmmoStateFlow();
        public void SetAmmoState(AmmoState state);
    }
}