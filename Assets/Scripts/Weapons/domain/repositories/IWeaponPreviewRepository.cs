using UnityEngine;

namespace Weapons.domain.repositories
{
    public interface IWeaponPreviewRepository
    {
        public Sprite GetWeaponPreview(long weaponId);
    }
}