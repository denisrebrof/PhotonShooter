using System;
using Ammo.domain.model;
using UniRx;
using Weapons.domain.repositories;
using Zenject;
using static Weapons.domain.model.Weapon.DamageType;

namespace Ammo.domain
{
    public class AmmoAvailableStateUseCase
    {
        [Inject] private ISelectedWeaponRepository selectedWeaponRepository;

        public IObservable<bool> GetAmmoAvailableStateFlow() => selectedWeaponRepository
            .GetSelectedWeaponFlow()
            .Select(weapon => weapon.Type != Melee);

        public bool GetAmmoAvailableState()
        {
            return selectedWeaponRepository.GetSelectedWeapon(out var weapon) && weapon.IsAmmoAvailable();
        }
    }
}