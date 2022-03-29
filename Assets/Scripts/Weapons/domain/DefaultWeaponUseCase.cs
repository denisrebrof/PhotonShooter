using System.Linq;
using Weapons.domain.model;
using Weapons.domain.repositories;
using Zenject;

namespace Weapons.domain
{
    public class DefaultWeaponUseCase
    {
        [Inject] private IWeaponsRepository weaponsRepository;

        public Weapon GetDefaultWeapon() => weaponsRepository.GetAvailableWeapons().First();
    }
}