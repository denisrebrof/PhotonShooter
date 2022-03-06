using UnityEngine;
using Weapons.data.dao;
using Weapons.domain.repositories;
using Zenject;

namespace Weapons.data
{
    public class WeaponPreviewRepository: IWeaponPreviewRepository
    {
        
        [Inject] private IWeaponEntitiesDao weaponEntitiesDao;
        
        public Sprite GetWeaponPreview(long weaponId) => weaponEntitiesDao.GetWeaponEntity((int) weaponId).preview;
    }
}