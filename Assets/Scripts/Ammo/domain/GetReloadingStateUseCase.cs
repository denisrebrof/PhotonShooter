using System;
using Ammo.domain.model;
using UniRx;
using Zenject;

namespace Ammo.domain
{
    public class GetReloadingStateUseCase
    {
        [Inject] private IAmmoStateRepository stateRepository;
        
        public IObservable<bool> GetIsReloadingFlow() => stateRepository.GetAmmoStateFlow().Select(state => state == AmmoState.Reloading);
    }
}