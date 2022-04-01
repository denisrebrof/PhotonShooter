using Ammo.domain.model;
using Ammo.domain.repository;
using Weapons.domain.model;
using Weapons.domain.repositories;
using Zenject;
using static Ammo.domain.ReloadAmmoUseCase.ReloadAmmoResult;

namespace Ammo.domain
{
    public class ReloadAmmoUseCase
    {
        [Inject] private IAmmoRepository ammoRepository;
        [Inject] private IAmmoStateRepository ammoStateRepository;
        [Inject] private ISelectedWeaponRepository selectedWeaponRepository;

        public ReloadAmmoResult ReloadAmmo()
        {
            if (!selectedWeaponRepository.GetSelectedWeapon(out var selectedWeapon)) return NoWeapon;
            if (!selectedWeapon.IsAmmoAvailable()) return NotReloadable;
            if (selectedWeapon.AmmoCapacity == ammoRepository.GetLoadedAmmoCount()) return FullAmmo; 
            ammoRepository.SetLoadedAmmo(selectedWeapon.AmmoCapacity);
            ammoStateRepository.SetAmmoState(AmmoState.Full);
            return Success;
        }

        public enum ReloadAmmoResult
        {
            Success,
            FullAmmo,
            NotReloadable,
            NoWeapon
        }
    }
}