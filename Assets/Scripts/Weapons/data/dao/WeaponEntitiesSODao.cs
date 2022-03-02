using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons.data.models;

namespace Weapons.data.dao
{
    // ReSharper disable once InconsistentNaming
    [CreateAssetMenu(menuName = "Weapons/WeaponsListDao")]
    public class WeaponEntitiesSODao : ScriptableObject, IWeaponEntitiesDao
    {
        [SerializeField] private List<WeaponEntity> entities = new List<WeaponEntity>();
        
        public List<WeaponEntity> GetWeaponEntities() => entities;

        public WeaponEntity GetWeaponEntity(int number) => entities[Math.Max(0, number - 1)];

    }
}