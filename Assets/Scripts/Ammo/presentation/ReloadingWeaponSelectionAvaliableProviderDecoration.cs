using Ammo.domain;
using Ammo.domain.model;
using Zenject;
using static Weapons.presentation.WeaponSelectionController;

namespace Ammo.presentation
{
    public class ReloadingWeaponSelectionAvailableProvider: IWeaponSelectionAvailableProvider
    {
        [Inject] private IAmmoStateRepository ammoStateRepository;
        public bool IsSelectionAvailable() => ammoStateRepository.GetAmmoState() != AmmoState.Reloading;
    }
}