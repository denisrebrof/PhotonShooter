using System;
using Ammo.domain.model;
using UniRx;
using Zenject;

namespace Ammo.domain
{
    public class GetReloadRequiredStateUseCase
    {
        [Inject] private IAmmoStateRepository stateRepository;
        
        public IObservable<bool> GetReloadRequiredFlow() => stateRepository.GetAmmoStateFlow().Select(state => state == AmmoState.Empty);
    }
}