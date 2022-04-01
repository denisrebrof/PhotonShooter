using Ammo.domain;
using Ammo.domain.model;
using Ammo.domain.repository;
using Zenject;
using static Weapons.presentation.WeaponSelectionController;

namespace Ammo.presentation
{
    public class ReloadWeaponSelectionAvailableProvider: IWeaponSelectionAvailableProvider
    {
        [Inject] private IAmmoStateRepository ammoStateRepository;
        public bool IsSelectionAvailable() => ammoStateRepository.GetAmmoState() != AmmoState.Reloading;
    }
}