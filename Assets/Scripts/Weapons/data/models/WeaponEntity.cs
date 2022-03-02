using Weapons.domain;
using Weapons.domain.model;

namespace Weapons.data.models
{
    public class WeaponEntity
    {
        public string Name;
        public int AmmoCapacity;
        public Weapon.DamageType Type;
    }
}