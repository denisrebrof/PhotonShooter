using UnityEngine;

namespace Weapons.domain.repositories
{
    public interface IWeaponPrefabRepository
    {
        public GameObject GetWeaponPrefab(long weaponId);
    }
}