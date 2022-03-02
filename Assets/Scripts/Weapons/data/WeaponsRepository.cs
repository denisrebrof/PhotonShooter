using System.Collections.Generic;
using System.Linq;
using Weapons.data.dao;
using Weapons.data.models;
using Weapons.domain;
using Weapons.domain.model;
using Weapons.domain.repositories;
using Zenject;

namespace Weapons.data
{
    public class WeaponsRepository : IWeaponsRepository
    {
        [Inject] private IWeaponEntitiesDao weaponEntitiesDao;

        public Weapon GetWeapon(long weaponId)
        {
            var entity = weaponEntitiesDao.GetWeaponEntity((int) weaponId);
            return ConvertToWeapon(entity, weaponId);
        }

        public List<Weapon> GetAvailableWeapons() => weaponEntitiesDao
            .GetWeaponEntities()
            .Select((entity, index) =>
                ConvertToWeapon(entity, (long) index)
            ).ToList();

        private static Weapon ConvertToWeapon(WeaponEntity entity, long id) => new Weapon(
            id = id,
            entity.Name,
            entity.AmmoCapacity,
            entity.Type
        );
    }
}