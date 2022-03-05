using System;
using Weapons.domain.repositories;
using Zenject;

namespace Weapons.domain
{
    public class SelectWeaponUseCase
    {
        [Inject] private ISelectedWeaponRepository selectedWeaponRepository;
        [Inject] private IWeaponsRepository weaponsRepository;

        public void SelectWeapon(int number)
        {
            var weapons = weaponsRepository.GetAvailableWeapons();
            if (weapons.Count == 0) return;
            var weaponIndex = Math.Clamp(number - 1, 0, weapons.Count - 1);
            selectedWeaponRepository.SetSelectedWeapon(weapons[weaponIndex].ID);
        }
    }
}