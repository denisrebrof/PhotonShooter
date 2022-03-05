using JetBrains.Annotations;
using UnityEngine;
using Weapons.data.dao;
using Weapons.domain.repositories;
using Zenject;

namespace Weapons.data
{
    public class WeaponPrefabRepository: IWeaponPrefabRepository
    {
        [Inject] private IWeaponEntitiesDao weaponEntitiesDao;
        
        public GameObject GetWeaponPrefab(long weaponId) => weaponEntitiesDao.GetWeaponEntity((int) weaponId).prefab;
    }
}