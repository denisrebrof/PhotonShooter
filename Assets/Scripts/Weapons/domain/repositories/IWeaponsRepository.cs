using System.Collections.Generic;
using Weapons.domain.model;

namespace Weapons.domain.repositories
{
    public interface IWeaponsRepository
    {
        public Weapon GetWeapon(long weaponId);
        public List<Weapon> GetAvailableWeapons();
    }
}