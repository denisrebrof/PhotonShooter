using System;
using UniRx;
using Weapons.domain.model;
using Weapons.domain.repositories;
using Zenject;

namespace Weapons.data
{
    public class SelectedWeaponInMemoryRepository : ISelectedWeaponRepository
    {
        [Inject] private IWeaponsRepository weaponsRepository;
        private const long UndefinedWeaponId = -1L;
        private readonly BehaviorSubject<long> selectedWeaponIdSubject = new(UndefinedWeaponId);

        public bool GetSelectedWeapon(out Weapon weapon)
        {
            if (selectedWeaponIdSubject.Value == UndefinedWeaponId)
            {
                weapon = null;
                return false;
            }

            weapon = weaponsRepository.GetWeapon(selectedWeaponIdSubject.Value);
            return true;
        }

        public IObservable<Weapon> GetSelectedWeaponFlow() => selectedWeaponIdSubject
            .Where(id => id != UndefinedWeaponId)
            .Select(weaponsRepository.GetWeapon);

        public void SetSelectedWeapon(long weaponId) => selectedWeaponIdSubject.OnNext(weaponId);
    }
}