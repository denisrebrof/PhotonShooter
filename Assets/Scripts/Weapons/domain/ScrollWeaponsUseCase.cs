using System;
using System.Linq;
using Weapons.domain.repositories;
using Zenject;

namespace Weapons.domain
{
    public class ScrollWeaponsUseCase
    {
        [Inject] private ISelectedWeaponRepository selectedWeaponRepository;
        [Inject] private IWeaponsRepository weaponsRepository;

        public void ScrollWeapon(ScrollDirection direction)
        {
            var weapons = weaponsRepository.GetAvailableWeapons();
            if (weapons.Count == 0 || !selectedWeaponRepository.GetSelectedWeapon(out var selectedWeapon)) return;

            var scrolledToWeaponIndex = 0;
            if (weapons.All(weapon => weapon.ID != selectedWeapon.ID))
            {
                scrolledToWeaponIndex = (direction == ScrollDirection.Next) ? 0 : weapons.Count - 1;
            }
            else
            {
                var weaponIndex = weapons.FindIndex(weapon => weapon.ID == selectedWeapon.ID);
                scrolledToWeaponIndex = (direction == ScrollDirection.Next) ? weaponIndex + 1 : weaponIndex - 1;
                scrolledToWeaponIndex %= weapons.Count;
            }

            selectedWeaponRepository.SetSelectedWeapon(weapons[scrolledToWeaponIndex].ID);
        }

        public enum ScrollDirection
        {
            Next,
            Previous
        }
    }
}