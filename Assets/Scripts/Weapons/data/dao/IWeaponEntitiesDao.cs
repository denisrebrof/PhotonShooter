using System.Collections.Generic;
using Weapons.data.models;

namespace Weapons.data.dao
{
    public interface IWeaponEntitiesDao
    {
        public List<WeaponEntity> GetWeaponEntities();
        public WeaponEntity GetWeaponEntity(int number);
    }
}